using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcorrencias;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.IO;

namespace DER.WebApp.Domain.Business
{
    public class GestaoOcorrenciaBLL
    {
        #region Construtor

        private GestaoOcorrenciaDAO gestaoOcorrenciaDAO;
        private GestaoInteressadoDAO gestaoInteressadoDAO;
        private GestaoOcupacaoDAO gestaoOcupacaoDAO;
        private GestaoOcorrenciaObservacaoDAO gestaoOcorrenciaObservacaoDAO;
        private GestaoOcorrenciaDocumentoDAO gestaoOcorrenciaDocumentoDAO;
        private UsuarioDAO usuarioDAO;
        private DerContext _context;

        public GestaoOcorrenciaBLL()
        {
            _context = new DerContext();
            gestaoOcorrenciaDAO = new GestaoOcorrenciaDAO(_context);
            gestaoOcupacaoDAO = new GestaoOcupacaoDAO(_context);
            gestaoInteressadoDAO = new GestaoInteressadoDAO(_context);
            gestaoOcorrenciaObservacaoDAO = new GestaoOcorrenciaObservacaoDAO(_context);
            gestaoOcorrenciaDocumentoDAO = new GestaoOcorrenciaDocumentoDAO(_context);
            usuarioDAO = new UsuarioDAO(_context);
        }

        #endregion

        #region Metodos Publicos


        public List<RetornoInteressadoOcupacaoViewModel> GetInteressadoByParams(InteressadoOcupacaoParansDTO viewModel, string UsuarioAtualizacao)
        {
            return gestaoInteressadoDAO.GetInteressadoByParams(viewModel, UsuarioAtualizacao);
        }

        public List<ListaGestaoOcorrenciaDTO> ObtemListaGestaoOcorrencia(string UsuarioAtualizacao)
        {
            return gestaoOcorrenciaDAO.ObtemListaGestaoOcorrencia(UsuarioAtualizacao);
        }

        public List<GestaoOcorrenciasViewModel> ObtemTodasOcorrencias(string UsuarioAtualizacao)
        {
            return gestaoOcorrenciaDAO.ObtemTodasOcorrencias(UsuarioAtualizacao);
        }

        public GestaoOcorrenciasViewModel ObtemInfoId(int id)
        {
            var retorno = gestaoOcorrenciaDAO.GetById(id);

            retorno.Observacoes = new List<GestaoObservacaoViewModel>();
            retorno.Documentos = new List<GestaoOcorrenciaDocumentoViewModel>();

            retorno.Observacoes.AddRange(gestaoOcorrenciaObservacaoDAO.GetByGestaoId(id));
            retorno.Documentos.AddRange(gestaoOcorrenciaDocumentoDAO.GetByGestaoId(id));

            return retorno;
        }

        public GestaoOcupacao ObtemId(int id)
        {
            return gestaoOcupacaoDAO.Get(id);
        }

        public void Excluir(int id)
        {
            gestaoOcorrenciaDAO.Excluir(id);
        }

        public GestaoOcorrenciaValidatorViewModel Inserir(GestaoOcorrenciasViewModel viewModel)
        {
            try
            {
                bool update = false;
                bool create = false;

                var domain = new GestaoOcorrencia()
                {
                    Id = viewModel.Id,
                    InteressadoId = viewModel.InteressadoId,
                    Documento = viewModel.Documento,
                    OcupacaoId = viewModel.OcupacaoId,
                    TipoOcupacaoId = viewModel.TipoOcupacaoId,
                    TrechoId = viewModel.TrechoId,
                    RodoviaId = viewModel.RodoviaId,
                    KmInicial = viewModel.KmInicial,
                    KmFinal = viewModel.KmFinal,
                    LadoId = viewModel.LadoId,
                    ResidenciaConservacaoId = viewModel.ResidenciaConservacaoId,
                    RegionalId = viewModel.RegionalId,
                    Latitude = viewModel.Latitude,
                    Longitude = viewModel.Longitude,
                    Titulo = viewModel.Titulo,
                    AssuntoId = viewModel.AssuntoId,
                    SeveridadeId = viewModel.SeveridadeId,
                    StatusId = viewModel.StatusId,
                    Descricao = viewModel.Descricao,
                    Observacao = viewModel.Observacao,
                    UsuarioAtualizacao = viewModel.UsuarioAtualizacao,
                    AdicionadoPor = viewModel.AdicionadoPor,
                    DataCadastro = viewModel.DataCadastro,
                    DataAtualizacao = viewModel.DataAtualizacao,
                    Ativo = viewModel.Ativo,
                    CodigoOcorrencia = DateTime.Now.ToString("yyMMddhhmmss"),
                };

                int idOcorrencia = 0;

                if (viewModel.Id == 0)
                {
                    idOcorrencia = gestaoOcorrenciaDAO.Inserir(domain);
                    create = true;
                }
                else
                {
                    idOcorrencia = viewModel.Id;
                    update = true;
                    gestaoOcorrenciaDAO.Update(domain);
                    gestaoOcorrenciaObservacaoDAO.ExcluirPorIdGestao(idOcorrencia);

                }

                this.AddObservacoes(viewModel.Observacoes, idOcorrencia, viewModel.UsuarioAtualizacao);
                this.AddDocumentos(viewModel.Documentos, idOcorrencia, viewModel.UsuarioAtualizacao);

                if(create)
                {
                    Emails Email = new Emails();
                    Email.Destinatario = "eduardo-veiga.silva@bureauveritas.com";
                    Email.Assunto = "Novo ocorrência cadastrada";
                    Email.CorpoEmail = $"Foi cadastrado um nova ocorrência Id: {idOcorrencia} Adicionado por: {domain.AdicionadoPor}";
                    DER.WebApp.Common.Helper.Email EmailHelper = new DER.WebApp.Common.Helper.Email();
                    EmailHelper.EnviarEmail(Email);
                }

                return new GestaoOcorrenciaValidatorViewModel() { valid = true, mensagem = "Cadastrado com sucesso" };
            }
            catch (Exception ex)
            {
                return new GestaoOcorrenciaValidatorViewModel() { valid = false, mensagem = ex.Message };
            }
        }

        public GestaoOcorrenciaValidatorViewModel InserirApi(GestaoOcorrenciasViewModelApi viewModel)
        {
            try
            {
                bool update = false;
                bool create = false;

                var domain = new GestaoOcorrencia()
                {
                    Id = viewModel.Id,
                    InteressadoId = viewModel.InteressadoId,
                    Documento = viewModel.Documento,
                    OcupacaoId = viewModel.OcupacaoId,
                    TipoOcupacaoId = viewModel.TipoOcupacaoId,
                    TrechoId = viewModel.TrechoId,
                    RodoviaId = viewModel.RodoviaId,
                    KmInicial = viewModel.KmInicial,
                    KmFinal = viewModel.KmFinal,
                    LadoId = viewModel.LadoId,
                    ResidenciaConservacaoId = viewModel.ResidenciaConservacaoId,
                    RegionalId = viewModel.RegionalId,
                    Latitude = viewModel.Latitude,
                    Longitude = viewModel.Longitude,
                    Titulo = viewModel.Titulo,
                    AssuntoId = viewModel.AssuntoId,
                    SeveridadeId = viewModel.SeveridadeId,
                    StatusId = viewModel.StatusId,
                    Descricao = viewModel.Descricao,
                    Observacao = viewModel.Observacao,
                    UsuarioAtualizacao = viewModel.UsuarioAtualizacao,
                    AdicionadoPor = viewModel.AdicionadoPor,
                    DataCadastro = viewModel.DataCadastro,
                    DataAtualizacao = viewModel.DataAtualizacao,
                    Ativo = true,
                    CodigoOcorrencia = viewModel.CodigoOcorrencia
                };

                int idOcorrencia = 0;

                if (viewModel.Id == 0)
                {
                    idOcorrencia = gestaoOcorrenciaDAO.Inserir(domain);
                    create = true;
                }
                else
                {
                    idOcorrencia = viewModel.Id;
                    update = true;
                    gestaoOcorrenciaDAO.Update(domain);
                    gestaoOcorrenciaObservacaoDAO.ExcluirPorIdGestao(idOcorrencia);

                }

                this.AddObservacoes(viewModel.Observacoes, idOcorrencia, viewModel.UsuarioAtualizacao);
                this.AddDocumentos(viewModel.Documentos, idOcorrencia, viewModel.UsuarioAtualizacao);


                if (create)
                {
                    Emails Email = new Emails();
                    Email.Destinatario = "eduardo-veiga.silva@bureauveritas.com";
                    Email.Assunto = "Novo ocorrência cadastrada pelo APP";
                    Email.CorpoEmail = $"Foi cadastrado um nova ocorrência pelo APP Id: {idOcorrencia} Adicionado por: {domain.AdicionadoPor}";
                    DER.WebApp.Common.Helper.Email EmailHelper = new DER.WebApp.Common.Helper.Email();
                    EmailHelper.EnviarEmail(Email);
                }

                return new GestaoOcorrenciaValidatorViewModel() { valid = true, mensagem = "Cadastrado com sucesso" };
            }
            catch (Exception ex)
            {
                return new GestaoOcorrenciaValidatorViewModel() { valid = false, mensagem = ex.Message };
            }
        }

        public void SalvarArquivo(GestaoOcorrenciaDocumentoViewModel documento)
        {
            if (documento != null)
            {
                this.InserirDocumento(documento);
            }

            //if (documento.Files != null)
            //{
            //    foreach (var item in documento.Files)
            //    {
            //        string path = "C:\\der\\arquivos\\";
            //        var Extensao = Path.GetExtension(item.FileName);
            //        var NomeArquivo = DateTime.Now.ToString("yyyyMMddHHmmss") + documento.TipoDocumentoId;
            //        var caminhoCompletoSalvar = path + NomeArquivo + Extensao;
            //        documento.Arquivo = caminhoCompletoSalvar;
            //        Directory.CreateDirectory(path);
            //        item.SaveAs(caminhoCompletoSalvar);

            //        this.InserirDocumento(documento);
            //    }
            //}
        }

        #endregion


        #region Metodos Privados

        private string SalvarArquivo(string arquivo, string arquivoNome)
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

        private void InserirDocumento(GestaoOcorrenciaDocumentoViewModel documento)
        {
            var domain = new GestaoOcorrenciaDocumento()
            {
                Documento = documento.Documento,
                Arquivo = documento.Arquivo,
                AdicionadoPor = documento.AdicionadoPor,
                DataCadastro = DateTime.Now
            };
            //CORRIGIR : GOMES
            gestaoOcorrenciaDocumentoDAO.Inserir(domain);
        }


        private void AddObservacoes(List<GestaoObservacaoViewModel> observacoes, int idOcorrencia, string UsuarioAtualizacao)
        {
            if (observacoes != null && observacoes.Count > 0)
            {
                foreach (var obs in observacoes)
                {
                    var observacao = new GestaoOcorrenciaObservacao()
                    {
                        GestaoOcorrenciaId = idOcorrencia,
                        Observacao = obs.Observacao,
                        Nome = obs.Nome,
                        Cargo = obs.Cargo,
                        UsuarioAtualizacao = UsuarioAtualizacao,
                        DataCadastro = DateTime.Now
                    };

                    gestaoOcorrenciaObservacaoDAO.Inserir(observacao);
                }
            }
        }

        private void AddDocumentos(List<GestaoOcorrenciaDocumentoViewModel> documentos, int idOcorrencia, string UsuarioAtualizacao)
        {
            if (documentos != null && documentos.Count > 0)
            {
                foreach (var doc in documentos)
                {
                    var documento = new GestaoOcorrenciaDocumento()
                    {
                        GestaoOcorrenciaId = idOcorrencia,
                        Documento = doc.Documento,
                        Arquivo = doc.Arquivo,
                        AdicionadoPor = UsuarioAtualizacao,
                        DataCadastro = doc.DataCadastro
                    };

                    gestaoOcorrenciaDocumentoDAO.DocumentoExistente(documento);
                    
                    // GOMES ALTERAR
                    //FAZER O FRONT TRAZER A INFORMACAO DE DELETE NO ID DO ARQUIVO (COLOCAR UM TRAÇO NA FRENTE)

                    if (documento.Id == 0) // && DOCUMENTO.IDCONTAINS("+"))
                    {
                        gestaoOcorrenciaDocumentoDAO.Inserir(documento);
                    }
                    // IF DOCUMENTO.ID.CONTAINS ("-"){
                    //                     // AO CHEGAR AQUI, DA UM REPLACE REMOVENDO O TRAÇO E MANDA PRA PROC DELETAR
                    // {                    
                }
            }
        }
        #endregion
    }
}