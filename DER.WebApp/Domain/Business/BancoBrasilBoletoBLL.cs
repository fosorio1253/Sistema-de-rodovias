using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DER.WebApp.Domain.Business
{
    public class BancoBrasilBoletoBLL
    {
        private DerContext _context;
        private BancoBrasilBoletoDAO _bancoBrasilBoletoDAO;
        private DadosMestresDAO _dadosMestresDAO;
        private BancoBrasilBoletoRespostaBLL _bancoBrasilBoletoRespostaBLL;
        private GestaoInteressadoBLL _gestaoInteressadoBLL;
        private ConfiguracaoSistemaBLL configuracaoSistemaBLL;
        

        private GestaoInteressadosViewModel interessado;
        private decimal valorPep;
        private bool _remuneracao;
        private DateTime _dataBoleto;

        public BancoBrasilBoletoBLL()
        {
            _context = new DerContext();
            _bancoBrasilBoletoDAO = new BancoBrasilBoletoDAO(_context);
            _bancoBrasilBoletoRespostaBLL = new BancoBrasilBoletoRespostaBLL();
            _dadosMestresDAO = new DadosMestresDAO(_context);
            _gestaoInteressadoBLL = new GestaoInteressadoBLL();
            configuracaoSistemaBLL = new ConfiguracaoSistemaBLL();
        }

        public byte[] GerarBoleto(int interessadoId, decimal valor, DateTime databoleto, int idFaturamento, bool remuneracao = false)
        {
            _remuneracao = remuneracao;
            _dataBoleto = databoleto;
            interessado = _gestaoInteressadoBLL.ObtemInfoId(interessadoId);
            valorPep = valor;

            return CreatePDF();

            if (_bancoBrasilBoletoDAO.ObtemTodosBoletos().Any(x => x.CpfCnpj.Equals(interessado.Documentos[0].Documento) && !x.pago))
                if(_bancoBrasilBoletoDAO.ObtemTodosBoletos().Any(x => DateTime.Parse(x.dataVencimentoTitulo) <= DateTime.Now))
                    return _bancoBrasilBoletoRespostaBLL.EmitirBoleto(_bancoBrasilBoletoDAO.ObtemTodosBoletos().Where(x => x.CpfCnpj.Equals(interessado.Documentos[0].Documento) && !x.pago).FirstOrDefault());
                else
                    return new byte[]{0};
            else
                return _bancoBrasilBoletoRespostaBLL.EmitirBoleto(ConstruirBoleto(idFaturamento));
        }

        private Boleto ConstruirBoleto(int idFaturamento)
        {
            var id = _bancoBrasilBoletoDAO.ObtemTodosBoletos().Count + 1;
            var idchar = string.Concat(Enumerable.Repeat("0", 10 - id.ToString().Length)) + (id).ToString();

            var boleto = new Boleto();
            boleto.IdFaturamento = idFaturamento;
            if (_remuneracao)
                boleto.TipoFaturamento = "Remuneração";
            else
                boleto.TipoFaturamento = "PEP";
            boleto.CpfCnpj = interessado.Documentos[0].Documento;
            boleto.pago = false;
            boleto.codigoAceiteTitulo = "N";
            boleto.codigoChaveUsuario = "";//codigo da chave de usuario
            boleto.codigoModalidadeTitulo = 1;
            boleto.codigoTipoCanalSolicitacao = 5;
            boleto.codigoTipoDesconto = 0;
            boleto.codigoTipoInscricaoPagador = boleto.CpfCnpj.Length > 11 ? 1 : 2;
            boleto.codigoTipoJuroMora = 0;
            boleto.codigoTipoMulta = 0;
            boleto.codigoTipoTitulo = 1;

            boleto.dataEmissaoTitulo = _dataBoleto.ToString("dd-MM-yyyy");
            if(_remuneracao)
                boleto.dataVencimentoTitulo = _dataBoleto.AddYears(1).ToString("dd-MM-yyyy");
            else
                boleto.dataVencimentoTitulo = _dataBoleto.AddDays(30).ToString("dd-MM-yyyy");

            boleto.indicadorPermissaoRecebimentoParcial = "N";
            boleto.nomeBairroPagador = interessado.Enderecos[0].Bairro;
            boleto.nomeMunicipioPagador = _dadosMestresDAO.ObterMunicipio(interessado.Enderecos[0].EstadoId);
            boleto.numeroCarteira = 17;
            boleto.numeroCepPagador = int.Parse(Regex.Match(interessado.Enderecos[0].CEP, @"\d+").Value);
            boleto.numeroConvenio = 0;//identificador
            boleto.numeroVariacaoCarteira = 0;
            boleto.siglaUfPagador = _dadosMestresDAO.ObterUF(interessado.Enderecos[0].EstadoId);
            boleto.textoEnderecoPagador = interessado.Enderecos[0].Logradouro;
            boleto.textoNumeroTituloCliente = "000" + boleto.numeroConvenio.ToString() + idchar;
            boleto.valorOriginalTitulo = valorPep;
            boleto.Producao = configuracaoSistemaBLL.GetProducao();

            var lboleto = new List<Boleto>();
            lboleto.Add(boleto);

            _bancoBrasilBoletoDAO.Inserir(lboleto);

            return boleto;
        }

        //metodo temporario para apresentação
        private byte[] CreatePDF()
        {
            var boletos = new Boleto2Net.Boletos();

            boletos.Banco = Boleto2Net.Banco.Instancia(Boleto2Net.Bancos.BancoDoBrasil);
            boletos.Banco.Cedente = new Boleto2Net.Cedente();
            boletos.Banco.Cedente.CPFCNPJ = "43.052.497/0001-02";
            boletos.Banco.Cedente.Nome = "DEPARTAMENTO DE ESTRADAS DE RODAGEM - DER/SP";
            boletos.Banco.Cedente.Observacoes = "";

            var conta = new Boleto2Net.ContaBancaria();
            conta.Agencia = "1897";
            conta.DigitoAgencia = "X";
            conta.OperacaoConta = string.Empty;
            conta.Conta = "00008377";
            conta.DigitoConta = "1";
            conta.CarteiraPadrao = "17";
            conta.VariacaoCarteiraPadrao = "019";
            conta.TipoCarteiraPadrao = Boleto2Net.TipoCarteira.CarteiraCobrancaSimples;
            conta.TipoFormaCadastramento = Boleto2Net.TipoFormaCadastramento.SemRegistro;
            conta.TipoImpressaoBoleto = Boleto2Net.TipoImpressaoBoleto.Empresa;
            conta.TipoDocumento = Boleto2Net.TipoDocumento.Tradicional;

            var enderecocedente = new Boleto2Net.Endereco();
            enderecocedente.UF = "SP";
            enderecocedente.Cidade = "";
            enderecocedente.CEP = "";
            enderecocedente.Bairro = "";
            enderecocedente.LogradouroEndereco = "";
            enderecocedente.LogradouroNumero = "";
            enderecocedente.LogradouroComplemento = "";
            
            boletos.Banco.Cedente.Codigo = "0000001";
            boletos.Banco.Cedente.CodigoDV = "";
            boletos.Banco.Cedente.CodigoTransmissao = "";
            boletos.Banco.Cedente.ContaBancaria = conta;
            boletos.Banco.Cedente.Endereco = enderecocedente;

            boletos.Banco.FormataCedente();

            var titulo = new Boleto2Net.Boleto(boletos.Banco);
            titulo.CodigoOcorrencia = "";
            titulo.NumeroDocumento = "";
            titulo.NumeroControleParticipante = "";
            titulo.NossoNumero = "00000010000000000";

            titulo.DataEmissao = _dataBoleto;
            if (_remuneracao)
                titulo.DataVencimento = _dataBoleto.AddYears(1);
            else
                titulo.DataVencimento = _dataBoleto.AddDays(30);

            titulo.ValorTitulo = valorPep;
            titulo.Aceite = "N";
            titulo.EspecieDocumento = Boleto2Net.TipoEspecieDocumento.RC;
            titulo.CodigoProtesto = Boleto2Net.TipoCodigoProtesto.NaoProtestar;
            titulo.DiasProtesto = 0;
            titulo.CodigoBaixaDevolucao = Boleto2Net.TipoCodigoBaixaDevolucao.NaoBaixarNaoDevolver;
            titulo.DiasBaixaDevolucao = 0;

            titulo.Sacado = new Boleto2Net.Sacado();
            titulo.Sacado.Nome = interessado.Nome;
            titulo.Sacado.CPFCNPJ = interessado.Documento ?? "00.000.000/0000-00";

            titulo.ValidarDados();
            boletos.Add(titulo);

            var boletoBancario = new Boleto2Net.BoletoBancario();
            boletoBancario.Boleto = boletos.FirstOrDefault();
            return boletoBancario.MontaBytesPDF(false);
        }

        public List<Boleto> ObterTodos()
        {
            return _bancoBrasilBoletoDAO.ObtemTodosBoletos();
        }
    }
}