using DER.WebApp.BancoBrasilRegistraBoleto;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class BancoBrasilBoletoRespostaBLL
    {
        private DerContext _context;
        private BancoBrasilBoletoRespostaDAO _bancoBrasilBoletoRespostaDAO;

        public BancoBrasilBoletoRespostaBLL()
        {
            _context = new DerContext();
            _bancoBrasilBoletoRespostaDAO = new BancoBrasilBoletoRespostaDAO(_context);
        }

        public byte[] EmitirBoleto(Models.Boleto boleto)
        {
            if (!_bancoBrasilBoletoRespostaDAO.ObtemTodosBoletosResposta().Any(x => x.Boleto_Resposta_Id.Equals(boleto.Boleto_Resposta_Id)))
                return CreatePDF(ProcessarResposta(new portTypeClient().RegistroTituloCobrancaAsync(CriarRequest(boleto)).Result), boleto);
            else
                return CreatePDF(_bancoBrasilBoletoRespostaDAO.ObtemTodosBoletosResposta().Where(x => x.Boleto_Resposta_Id.Equals(boleto.Boleto_Resposta_Id)).FirstOrDefault(), boleto);
        }

        private byte[] CreatePDF(Models.BoletoResposta boletoResposta, Models.Boleto boleto)
        {
            var boletos = new Boleto2Net.Boletos();
            var enderecocedente = new Boleto2Net.Endereco();
            var conta = new Boleto2Net.ContaBancaria();

            conta.Agencia = boletoResposta.codigoPrefixoDependenciaBeneficiario.ToString();
            conta.DigitoAgencia = "";
            conta.OperacaoConta = string.Empty;
            conta.Conta = "";
            conta.DigitoConta = "";
            conta.CarteiraPadrao = "";
            conta.VariacaoCarteiraPadrao = "";
            conta.TipoCarteiraPadrao = Boleto2Net.TipoCarteira.CarteiraCobrancaSimples;
            conta.TipoFormaCadastramento = Boleto2Net.TipoFormaCadastramento.SemRegistro;
            conta.TipoImpressaoBoleto = Boleto2Net.TipoImpressaoBoleto.Empresa;
            conta.TipoDocumento = Boleto2Net.TipoDocumento.Tradicional;

            enderecocedente.UF = boletoResposta.siglaUfBeneficiario;
            enderecocedente.Cidade = boletoResposta.nomeMunicipioBeneficiario;
            enderecocedente.CEP = boletoResposta.codigoCepBeneficiario.ToString();
            enderecocedente.Bairro = boletoResposta.nomeBairroBeneficiario;
            enderecocedente.LogradouroEndereco = boletoResposta.nomeLogradouroBeneficiario;
            enderecocedente.LogradouroNumero = "";
            enderecocedente.LogradouroComplemento = "";

            boletos.Banco = Boleto2Net.Banco.Instancia(Boleto2Net.Bancos.BancoDoBrasil);
            boletos.Banco.Cedente = new Boleto2Net.Cedente();
            boletos.Banco.Cedente.CPFCNPJ = "";
            boletos.Banco.Cedente.Nome = "";
            boletos.Banco.Cedente.Observacoes = "";
            boletos.Banco.Cedente.Codigo = "";
            boletos.Banco.Cedente.CodigoDV = "";
            boletos.Banco.Cedente.CodigoTransmissao = boleto.Boleto_Id.ToString();
            boletos.Banco.Cedente.ContaBancaria = conta;
            boletos.Banco.Cedente.Endereco = enderecocedente;

            boletos.Banco.FormataCedente();

            var titulo = new Boleto2Net.Boleto(boletos.Banco);
            titulo.CodigoOcorrencia = "";
            titulo.NumeroDocumento = "";
            titulo.NumeroControleParticipante = "";
            titulo.NossoNumero = "";
            titulo.DataEmissao = DateTime.Parse(boleto.dataEmissaoTitulo);
            titulo.DataVencimento = DateTime.Parse(boleto.dataVencimentoTitulo);
            titulo.ValorTitulo = boleto.valorOriginalTitulo;
            titulo.Aceite = boleto.codigoAceiteTitulo;
            titulo.EspecieDocumento = Boleto2Net.TipoEspecieDocumento.DM;
            titulo.CodigoProtesto = Boleto2Net.TipoCodigoProtesto.NaoProtestar;
            titulo.DiasProtesto = 0;
            titulo.CodigoBaixaDevolucao = Boleto2Net.TipoCodigoBaixaDevolucao.NaoBaixarNaoDevolver;
            titulo.DiasBaixaDevolucao = 0;

            titulo.ValidarDados();
            boletos.Add(titulo);

            var pdf = new Boleto2Net.BoletoBancario();

            pdf.Boleto = boletos.FirstOrDefault();
            return pdf.MontaBytesPDF(false);
        }

        private Models.BoletoResposta ProcessarResposta(RegistroTituloCobrancaResponse resposta)
        {
            var boletoResposta = new Models.BoletoResposta();
            boletoResposta.siglaSistemaMensagem                     = resposta.siglaSistemaMensagem;
            boletoResposta.codigoRetornoPrograma                    = resposta.codigoRetornoPrograma;
            boletoResposta.nomeProgramaErro                         = resposta.nomeProgramaErro;
            boletoResposta.textoMensagemErro                        = resposta.textoMensagemErro;
            boletoResposta.numeroPosicaoErroPrograma                = resposta.numeroPosicaoErroPrograma;
            boletoResposta.codigoTipoRetornoPrograma                = resposta.codigoTipoRetornoPrograma;
            boletoResposta.textoNumeroTituloCobrancaBb              = resposta.textoNumeroTituloCobrancaBb;
            boletoResposta.numeroCarteiraCobranca                   = resposta.numeroCarteiraCobranca;
            boletoResposta.numeroVariacaoCarteiraCobranca           = resposta.numeroVariacaoCarteiraCobranca;
            boletoResposta.codigoPrefixoDependenciaBeneficiario     = resposta.codigoPrefixoDependenciaBeneficiario;
            boletoResposta.numeroContaCorrenteBeneficiario          = resposta.numeroContaCorrenteBeneficiario;
            boletoResposta.codigoCliente                            = resposta.codigoCliente;
            boletoResposta.linhaDigitavel                           = resposta.linhaDigitavel;
            boletoResposta.codigoBarraNumerico                      = resposta.codigoBarraNumerico;
            boletoResposta.codigoTipoEnderecoBeneficiario           = resposta.codigoTipoEnderecoBeneficiario;
            boletoResposta.nomeLogradouroBeneficiario               = resposta.nomeLogradouroBeneficiario;
            boletoResposta.nomeBairroBeneficiario                   = resposta.nomeBairroBeneficiario;
            boletoResposta.nomeMunicipioBeneficiario                = resposta.nomeMunicipioBeneficiario;
            boletoResposta.codigoMunicipioBeneficiario              = resposta.codigoMunicipioBeneficiario;
            boletoResposta.siglaUfBeneficiario                      = resposta.siglaUfBeneficiario;
            boletoResposta.codigoCepBeneficiario                    = resposta.codigoCepBeneficiario;
            boletoResposta.indicadorComprovacaoBeneficiario         = resposta.indicadorComprovacaoBeneficiario;
            boletoResposta.numeroContratoCobranca                   = resposta.numeroContratoCobranca;

            var lBoletoResposta = new List<Models.BoletoResposta>();
            lBoletoResposta.Add(boletoResposta);
            _bancoBrasilBoletoRespostaDAO.Inserir(lBoletoResposta);

            return boletoResposta;
        }

        private RegistroTituloCobrancaRequest CriarRequest(Models.Boleto boleto)
        {
            var retorno = new RegistroTituloCobrancaRequest();

            retorno.codigoAceiteTitulo                      = boleto.codigoAceiteTitulo;
            retorno.codigoChaveUsuario                      = boleto.codigoChaveUsuario;
            retorno.codigoModalidadeTitulo                  = (short)boleto.codigoModalidadeTitulo;
            retorno.codigoTipoCanalSolicitacao              = (short)boleto.codigoTipoCanalSolicitacao;
            retorno.codigoTipoContaCaucao                   = (short)boleto.codigoTipoContaCaucao;
            retorno.codigoTipoDesconto                      = (short)boleto.codigoTipoDesconto;
            retorno.codigoTipoInscricaoAvalista             = (short)boleto.codigoTipoInscricaoAvalista;
            retorno.codigoTipoInscricaoPagador              = (short)boleto.codigoTipoInscricaoPagador;
            retorno.codigoTipoJuroMora                      = (short)boleto.codigoTipoJuroMora;
            retorno.codigoTipoMulta                         = (short)boleto.codigoTipoMulta;
            retorno.codigoTipoTitulo                        = (short)boleto.codigoTipoTitulo;
            retorno.dataDescontoTitulo                      = boleto.dataDescontoTitulo;
            retorno.dataEmissaoTitulo                       = boleto.dataEmissaoTitulo;
            retorno.dataMultaTitulo                         = boleto.dataMultaTitulo;
            retorno.dataVencimentoTitulo                    = boleto.dataVencimentoTitulo;
            retorno.indicadorPermissaoRecebimentoParcial    = boleto.indicadorPermissaoRecebimentoParcial;
            retorno.nomeAvalistaTitulo                      = boleto.nomeAvalistaTitulo;
            retorno.nomeBairroPagador                       = boleto.nomeBairroPagador;
            retorno.nomeMunicipioPagador                    = boleto.nomeMunicipioPagador;
            retorno.nomePagador                             = boleto.nomePagador;
            retorno.numeroCarteira                          = (short)boleto.numeroCarteira;
            retorno.numeroCepPagador                        = boleto.numeroCepPagador;
            retorno.numeroConvenio                          = boleto.numeroConvenio;
            retorno.numeroInscricaoAvalista                 = (short)boleto.numeroInscricaoAvalista;
            retorno.numeroInscricaoPagador                  = (short)boleto.numeroInscricaoPagador;
            retorno.numeroVariacaoCarteira                  = (short)boleto.numeroVariacaoCarteira;
            retorno.percentualDescontoTitulo                = boleto.percentualDescontoTitulo;
            retorno.percentualJuroMoraTitulo                = boleto.percentualJuroMoraTitulo;
            retorno.percentualMultaTitulo                   = boleto.percentualMultaTitulo;
            retorno.quantidadeDiaProtesto                   = (short)boleto.quantidadeDiaProtesto;
            retorno.siglaUfPagador                          = boleto.siglaUfPagador;
            retorno.textoCampoUtilizacaoBeneficiario        = boleto.textoCampoUtilizacaoBeneficiario;
            retorno.textoDescricaoTipoTitulo                = boleto.textoDescricaoTipoTitulo;
            retorno.textoEnderecoPagador                    = boleto.textoEnderecoPagador;
            retorno.textoMensagemBloquetoOcorrencia         = boleto.textoMensagemBloquetoOcorrencia;
            retorno.textoNumeroTelefonePagador              = boleto.textoNumeroTelefonePagador;
            retorno.textoNumeroTituloBeneficiario           = boleto.textoNumeroTituloBeneficiario;
            retorno.textoNumeroTituloCliente                = boleto.textoNumeroTituloCliente;
            retorno.valorAbatimentoTitulo                   = boleto.valorAbatimentoTitulo;
            retorno.valorDescontoTitulo                     = boleto.valorDescontoTitulo;
            retorno.valorJuroMoraTitulo                     = boleto.valorJuroMoraTitulo;
            retorno.valorMultaTitulo                        = boleto.valorMultaTitulo;
            retorno.valorOriginalTitulo                     = boleto.valorOriginalTitulo;

            return retorno;
        }
    }
}