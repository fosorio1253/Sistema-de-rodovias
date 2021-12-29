using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.ViewModels.Validadores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class GestaoInteressadoBLL
    {
        #region Construtor

        private GestaoInteressadoDAO gestaoInteressadoDAO;
        private GestaoInteressadoEnderecoDAO gestaoInteressadoEnderecoDAO;
        private GestaoInteressadoContatoDAO gestaoInteressadoContatoDAO;
        private GestaoInteressadoDocumentoDAO gestaoInteressadoDocumentoDAO;
        private GestaoInteressadoTipoDeConcessaoDAO gestaoInteressadoTipoDeConcessaoDAO;
        private GestaoInteressadoObservacaoDAO gestaoInteressadoObservacaoDAO;
        private UsuarioDAO usuarioDAO;

        private DerContext _context;

        public GestaoInteressadoBLL()
        {
            _context = new DerContext();
            gestaoInteressadoDAO = new GestaoInteressadoDAO(_context);
            gestaoInteressadoEnderecoDAO = new GestaoInteressadoEnderecoDAO(_context);
            gestaoInteressadoContatoDAO = new GestaoInteressadoContatoDAO(_context);
            gestaoInteressadoObservacaoDAO = new GestaoInteressadoObservacaoDAO(_context);
            gestaoInteressadoDocumentoDAO = new GestaoInteressadoDocumentoDAO(_context);
            gestaoInteressadoTipoDeConcessaoDAO = new GestaoInteressadoTipoDeConcessaoDAO(_context);
            usuarioDAO = new UsuarioDAO(_context);
        }

        #endregion


        #region Metodos Publicos
        

        public List<UsuarioContatoConsultaViewModel> GetByParans(GestaoContatoViewModel viewModel)
        {
            return gestaoInteressadoContatoDAO.GetByParans(viewModel);
        }

        public GestaoContatoVisualizarViewModel GetContatoById(int usuarioId)
        {
            var usuario = usuarioDAO.Get(usuarioId);

            var retorno = new GestaoContatoVisualizarViewModel()
            {
                Cargo = usuario.Cargo,
                Nome = usuario.Nome,
                DDD = usuario.DDD,
                Email = usuario.Email,
                Login = usuario.Login,
                Telefone = usuario.TelefoneRamal,
                EmpresasIDs = usuario.EmpresasIDs,
                GruposIDs = usuario.GruposIDs
            };

            retorno.EmpresasIDs = new List<int>();

            if (usuario.EmpresasIDs != null)
            {
                retorno.EmpresasIDs.AddRange(usuario.EmpresasIDs);
            }

            retorno.GruposIDs = new List<int>();

            if (usuario.GruposIDs != null)
            {
                retorno.GruposIDs.AddRange(usuario.GruposIDs);
            }


            return retorno;
        }

        public List<ListaGestaoInteressadoDTO> ObtemListaGestaoInteressados(int UsuarioPerfilId, int UsuarioEmpresaId, int UsuarioId)
        {
            return gestaoInteressadoDAO.GetListGestaoInteressados(UsuarioPerfilId, UsuarioEmpresaId, UsuarioId);
        }

        public GestaoInteressadosViewModel ObtemInfoId(int id)
        {
            var retorno = gestaoInteressadoDAO.GetById(id);

            retorno.Enderecos = new List<GestaoEnderecoViewModel>();
            retorno.Contatos = new List<GestaoContatoViewModel>();
            retorno.Observacoes = new List<GestaoObservacaoViewModel>();
            retorno.Documentos = new List<GestaoDocumentoViewModel>();
            retorno.TiposDeConcessoes = new List<TipoDeConcessaoViewModel>();

            retorno.Enderecos.AddRange(gestaoInteressadoEnderecoDAO.GetByGestaoId(id));
            retorno.Contatos.AddRange(gestaoInteressadoContatoDAO.GetByGestaoId(id));
            retorno.Observacoes.AddRange(gestaoInteressadoObservacaoDAO.GetByGestaoId(id));
            retorno.Documentos.AddRange(gestaoInteressadoDocumentoDAO.GetByGestaoId(id));
            retorno.TiposDeConcessoes.AddRange(gestaoInteressadoTipoDeConcessaoDAO.GetByGestaoId(id));

            return retorno;
        }

        public GestaoInteressado ObtemId(int id)
        {
            return gestaoInteressadoDAO.Get(id);
        }

        public GestaoInteressadoValidatorViewModel Inserir(GestaoInteressadosViewModel viewModel)
        {
            try
            {
                var domain = new GestaoInteressado()
                {
                    Id = viewModel.Id,
                    NumeroSPDOC = viewModel.NumeroSPDOC,
                    StatusSPDOC = viewModel.StatusSPDOC,
                    Nome = viewModel.Nome,
                    Telefone = viewModel.Telefone,
                    NaturezaJuridicaId = viewModel.NaturezaJuridicaId,
                    Documento = viewModel.Documento,
                    MatrizOuFilial = (viewModel.TipoEmpresaId == 44) ? "Matriz" : "Filial",
                    StatusAprovacaoId = viewModel.StatusId,
                    UsuarioAtualizacao = viewModel.UsuarioAtualizacao,
                    DataCadastro = DateTime.Now,
                    NomeFantasia = viewModel.NomeFantasia,
                    TipoDeInteressadoId = viewModel.TipoInteressadoId,
                    //ValidoAte = viewModel.Validade,
                };

                string ExisteValidade = gestaoInteressadoDAO.ConsultarValidade(viewModel.Id);
                if (domain.StatusAprovacaoId == (int)StatusAprovacaoEnum.Credenciado &&  String.IsNullOrEmpty(ExisteValidade))
                {
                    domain.ValidoAte = DateTime.Now.AddYears(1);

                    var usuario = usuarioDAO.GetByDocumento(viewModel.Documento);

                    Emails Email = new Emails();
                    Email.Destinatario = usuario.Email;
                    Email.Assunto = "SGFD - Credenciamento de Interessado.";
                    Email.CorpoEmail = $"Olá {usuario.Nome}, o seu cadastro no Sistema de Gestão de Faixas de Domínio foi aprovado.";

                    DER.WebApp.Common.Helper.Email EmailHelper = new Common.Helper.Email();
                    EmailHelper.EnviarEmail(Email);
                }

                if (domain.StatusAprovacaoId == (int)StatusAprovacaoEnum.Reprovado)
                {
                    domain.ValidoAte = DateTime.Now;

                    var usuario = usuarioDAO.GetByDocumento(domain.Documento);

                    Emails Email = new Emails();
                    Email.Destinatario = usuario.Email;
                    Email.Assunto = "SGFD - Credenciamento de Interessado.";
                    Email.CorpoEmail = $"Olá {usuario.Nome}, o seu cadastro no Sistema de Gestão de Faixas de Domínio foi reprovado.";

                    DER.WebApp.Common.Helper.Email EmailHelper = new Common.Helper.Email();
                    EmailHelper.EnviarEmail(Email);
                }               

                int idGestao = 0;

                if (viewModel.Id == 0)
                {
                    var UsuarioId = PerfilUsuario.UsuarioId;
                    idGestao = gestaoInteressadoDAO.Inserir(domain, UsuarioId);
                }
                else
                {
                    idGestao = viewModel.Id;
                    gestaoInteressadoDAO.Update(domain);

                    gestaoInteressadoEnderecoDAO.ExcluirPorIdGestao(idGestao);
                    gestaoInteressadoTipoDeConcessaoDAO.ExcluirPorIdGestao(idGestao);
                    gestaoInteressadoContatoDAO.ExcluirPorIdGestao(idGestao);
                    gestaoInteressadoObservacaoDAO.ExcluirPorIdGestao(idGestao);
                }

                this.AddEnderecos(viewModel.Enderecos, idGestao);

                this.AddContatos(viewModel.Contatos, idGestao);

                this.AddObservacoes(viewModel.Observacoes, idGestao);

                this.AddDocumentos(viewModel.Documentos, idGestao, viewModel.UsuarioAtualizacao);

                this.AddConcessao(viewModel.TiposDeConcessoes, idGestao);


                return new GestaoInteressadoValidatorViewModel() { valid = true };
            }
            catch (Exception ex)
            {
                return new GestaoInteressadoValidatorViewModel() { valid = false };
            }
        }

        public void Excluir(int id)
        {
            gestaoInteressadoDAO.Excluir(id);
        }

        #endregion


        #region Metodos Privados

        private void AddEnderecos(List<GestaoEnderecoViewModel> enderecos, int idGestao)
        {
            if (enderecos != null && enderecos.Count > 0)
            {
                int i = 0;
                bool principal = false;

                foreach (var endereco in enderecos)
                {
                    principal = i == 0 ? true : false;
                    var end = new GestaoInteressadoEndereco()
                    {
                        GestaoInteressadoId = idGestao,
                        UnidadeId = endereco.EstadoId,
                        Logradouro = endereco.Logradouro,
                        CEP = endereco.CEP,
                        Numero = (!string.IsNullOrEmpty(endereco.Numero)) ? endereco.Numero : string.Empty,
                        Complemento = (!string.IsNullOrEmpty(endereco.Complemento)) ? endereco.Complemento : string.Empty,
                        Bairro = (!string.IsNullOrEmpty(endereco.Bairro)) ? endereco.Bairro : string.Empty,
                        MunicipioId = endereco.MunicipioId,
                        NomeDoContato = (!string.IsNullOrEmpty(endereco.NomeContato)) ? endereco.NomeContato : string.Empty,
                        Principal = principal,
                    };

                    gestaoInteressadoEnderecoDAO.Inserir(end);

                    i++;
                }
            }
        }

        private void AddContatos(List<GestaoContatoViewModel> contatos, int idGestao)
        {
            if (contatos != null && contatos.Count > 0)
            {
                int i = 0;
                //bool principal = false;
                int principal = 0;

                foreach (var contato in contatos)
                {
                    //principal = i == 0 ? true : false;
                    principal = i == 0 ? 1 : 0;
                    var cont = new GestaoInteressadoContato()
                    {
                        Id = contato.Id,
                        GestaoInteressadoId = idGestao,
                        UsuarioId = contato.UsuarioId,
                        Principal = principal
                    };

                    gestaoInteressadoContatoDAO.Inserir(cont);

                    i++;
                }
            }
        }

        private void AddObservacoes(List<GestaoObservacaoViewModel> observacoes, int idGestao)
        {
            if (observacoes != null && observacoes.Count > 0)
            {
                foreach (var obs in observacoes)
                {
                    var observacao = new GestaoInteressadoObservacao()
                    {
                        GestaoInteressadoId = idGestao,
                        Data = DateTime.Now,
                        Observacao = obs.Observacao,
                        AdicionadoPor = obs.AdicionadoPor
                    };

                    gestaoInteressadoObservacaoDAO.Inserir(observacao);
                }
            }
        }

        private void AddDocumentos(List<GestaoDocumentoViewModel> documentos, int idGestao, string UsuarioAtualizacao)
        {
            if (documentos != null && documentos.Count > 0)
            {
                foreach (var doc in documentos)
                {
                    var documento = new GestaoInteressadoDocumento()
                    {
                        GestaoInteressadoId = idGestao,
                        Documento = doc.Documento,
                        Arquivo = this.SalvarArquivo(doc.Arquivo, doc.ArquivoNome),                        
                        AdicionadoPor = UsuarioAtualizacao,
                        DataCadastro = DateTime.Now
                    };

                    //gestaoInteressadoDocumentoDAO.DocumentoExistente(documento);

                    if (documento.Arquivo != null)
                    {
                        gestaoInteressadoDocumentoDAO.Inserir(documento);
                    }
                }
            }
        }

        private void AddConcessao(List<TipoDeConcessaoViewModel> tiposDeConcessoes, int idGestao)
        {
            if (tiposDeConcessoes != null && tiposDeConcessoes.Count > 0)
            {
                foreach (var tipoConcessao in tiposDeConcessoes)
                {
                    var concessao = new GestaoInteressadoTipoDeConcessao()
                    {
                        TipoDeConcessaoId = tipoConcessao.TipoConcessaoId,
                        Marcado = tipoConcessao.Marcado,
                        GestaoInteressadoId = idGestao
                    };

                    gestaoInteressadoTipoDeConcessaoDAO.Inserir(concessao);
                }
            }
        }

        private string SalvarArquivo(string arquivo, string arquivoNome)
        {
            try
            {
                string caminhoCompletoSalvar = string.Empty;

                if (!string.IsNullOrEmpty(arquivo))
                {
                    arquivo = arquivo.Replace(@"data:application/pdf;base64,", string.Empty);
                    arquivo = arquivo.Replace(@"data:image/jpeg;base64,", string.Empty);
                    arquivo = arquivo.Replace(@"data:image/jpg;base64,", string.Empty);
                    arquivo = arquivo.Replace(@"data:application/jpg;base64,", string.Empty);

                    Guid nomeArquivo = Guid.NewGuid();
                    string path = "C:\\der\\arquivos\\";
                    var Extensao = Path.GetExtension(arquivoNome);
                    var NomeArquivo = nomeArquivo;
                    caminhoCompletoSalvar = path + NomeArquivo + Extensao;
                    var caminho = @"C:\der\arquivos\" + NomeArquivo + Extensao;

                    if (!File.Exists(caminho))
                    {
                        byte[] arrBytes = Convert.FromBase64String(arquivo);
                        System.IO.FileStream stream = new FileStream(caminhoCompletoSalvar, FileMode.CreateNew);
                        System.IO.BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(arrBytes, 0, arrBytes.Length);
                        writer.Close();
                    }

                    return caminhoCompletoSalvar.Replace("C:\\der\\arquivos\\", string.Empty);
                }
                else
                {
                    return arquivoNome;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}