using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.IO;
using DER.WebApp.Helper;
using DER.WebApp.Common.Helper;
using DER.WebApp.Models.Enum;

namespace DER.WebApp.Domain.Business
{
    public class GestaoOcupacaoBLL
    {
        #region Construtor

        private GestaoInteressadoDAO gestaoInterssadoDAO;
        private GestaoOcupacaoDAO gestaoOcupacaoDAO;
        private GestaoOcupacaoOcorrenciaDAO gestaoOcupacaoOcorrenciaDAO;
        private GestaoOcupacaoTrechoDAO gestaoOcupacaoTrechoDAO;
        private GestaoOcupacaoDocumentoDAO gestaoOcupacaoDocumentoDAO;
        private GestaoOcupacaoParecerDAO gestaoOcupacaoParecerDAO;
        private GestaoOcupacaoDeferimentoDAO gestaoOcupacaoDeferimentoDAO;
        private GestaoOcupacaoOcupacaoDAO gestaoOcupacaoOcupacaoDAO;
        private GestaoOcupacaoTrechoInterferenciaDAO gestaoOcupacaoTrechoInterferenciaDAO;
        private GestaoOcupacaoCancelamentoDAO gestaoOcupacaoCancelamentoDAO;
        private GestaoOcupacaoManutencaoDAO gestaoOcupacaoManutencaoDAO;
        private GestaoOcupacaoRegularizacaoDAO gestaoOcupacaoRegularizacaoDAO;
        private GestaoOcupacaoRetificacaoDAO gestaoOcupacaoRetificacaoDAO;
        private GestaoOcupacaoTransferenciaDAO gestaoOcupacaoTransferenciaDAO;
        private GestaoOcupacaoWorkflowDAO gestaoOcupacaoWorkflowDAO;
        private UsuarioDAO usuarioDAO;


        private DerContext _context;

        public GestaoOcupacaoBLL()
        {
            _context = new DerContext();
            gestaoOcupacaoDAO = new GestaoOcupacaoDAO(_context);
            gestaoOcupacaoOcorrenciaDAO = new GestaoOcupacaoOcorrenciaDAO(_context);
            gestaoOcupacaoTrechoDAO = new GestaoOcupacaoTrechoDAO(_context);
            gestaoInterssadoDAO = new GestaoInteressadoDAO(_context);
            gestaoOcupacaoDocumentoDAO = new GestaoOcupacaoDocumentoDAO(_context);
            gestaoOcupacaoParecerDAO = new GestaoOcupacaoParecerDAO(_context);
            gestaoOcupacaoDeferimentoDAO = new GestaoOcupacaoDeferimentoDAO(_context);
            gestaoOcupacaoOcupacaoDAO = new GestaoOcupacaoOcupacaoDAO(_context);
            gestaoOcupacaoTrechoInterferenciaDAO = new GestaoOcupacaoTrechoInterferenciaDAO(_context);
            gestaoOcupacaoCancelamentoDAO = new GestaoOcupacaoCancelamentoDAO(_context);
            gestaoOcupacaoManutencaoDAO = new GestaoOcupacaoManutencaoDAO(_context);
            gestaoOcupacaoRegularizacaoDAO = new GestaoOcupacaoRegularizacaoDAO(_context);
            gestaoOcupacaoRetificacaoDAO = new GestaoOcupacaoRetificacaoDAO(_context);
            gestaoOcupacaoTransferenciaDAO = new GestaoOcupacaoTransferenciaDAO(_context);
            gestaoOcupacaoWorkflowDAO = new GestaoOcupacaoWorkflowDAO(_context);
            usuarioDAO = new UsuarioDAO(_context);
        }

        #endregion

        #region Metodos Publicos

        public List<RetornoInteressadoOcupacaoViewModel> GetInteressadoByParams(InteressadoOcupacaoParansDTO viewModel, string UsuarioAtualizacao)
        {
            return gestaoInterssadoDAO.GetInteressadoByParams(viewModel, UsuarioAtualizacao);
        }

        public List<ListaGestaoOcupacaoDTO> GetListGestaoOcupacao(int UsuarioPerfilId, int UsuarioEmpresaIdSessao, int UsuarioIdSessao)
        {
            return gestaoOcupacaoDAO.GetListGestaoOcupacao(UsuarioPerfilId, UsuarioEmpresaIdSessao, UsuarioIdSessao);
        }

        public List<GestaoOcupacaoViewModel> GetListGestaoOcupacaoComTrecho()
        {
            try
            {
                var UsuarioIdSessao = PerfilUsuario.UsuarioId;
                var UsuarioEmpresaId = PerfilUsuario.UsuarioEmpresaId;
                var UsuarioPerfilId = PerfilUsuario.UsuarioPerfilId;
                if (UsuarioPerfilId == 23)
                {
                    UsuarioPerfilId = 1;
                    UsuarioIdSessao = 0;
                    UsuarioEmpresaId = 0;
                }
                var ocupacoes = gestaoOcupacaoDAO.GetListGestaoOcupacao(UsuarioPerfilId, UsuarioEmpresaId, UsuarioIdSessao);
                List<GestaoOcupacaoViewModel> ocupacoesWithData = new List<GestaoOcupacaoViewModel>();

                foreach (ListaGestaoOcupacaoDTO oc in ocupacoes)
                {
                    var upd = ObtemInfoId(oc.Id);
                    ocupacoesWithData.Add(upd);

                }
                return ocupacoesWithData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GestaoOcupacaoViewModel ObtemInfoId(int id)
        {
            try
            {
                var retorno = gestaoOcupacaoDAO.GetById(id);

                retorno.Ocupacao = new GestaoOcupacaoOcupacaoViewModel();
                retorno.Parecer = new GestaoOcupacaoParecerViewModel();
                retorno.Deferimento = new GestaoOcupacaoDeferimentoViewModel();
                retorno.Documentos = new List<GestaoOcupacaoDocumentoViewModel>();
                retorno.Ocorrencias = new List<RetornoOcorrenciaViewModel>();
                retorno.Trechos = new List<GestaoOcupacoesTrechoViewModel>();

                retorno.Ocupacao = gestaoOcupacaoOcupacaoDAO.GetByOcupacaoId(id);
                retorno.Parecer = gestaoOcupacaoParecerDAO.GetByOcupacaoId(id);
                retorno.Deferimento = gestaoOcupacaoDeferimentoDAO.GetByOcupacaoId(id);
                retorno.Documentos.AddRange(gestaoOcupacaoDocumentoDAO.GetByOcupacaoId(id));
                retorno.Ocorrencias.AddRange(gestaoOcupacaoOcorrenciaDAO.GetByOcupacaoId(id));
                retorno.Trechos.AddRange(gestaoOcupacaoTrechoDAO.GetByOcupacaoId(id));
                retorno.Cancelamento = gestaoOcupacaoCancelamentoDAO.GetByOcupacaoId(id);
                retorno.Manutencao = gestaoOcupacaoManutencaoDAO.GetByOcupacaoId(id);
                retorno.Regularizacao = gestaoOcupacaoRegularizacaoDAO.GetByOcupacaoId(id);
                retorno.Retificacao = gestaoOcupacaoRetificacaoDAO.GetByOcupacaoId(id);
                retorno.Transferencia = gestaoOcupacaoTransferenciaDAO.GetByOcupacaoId(id);

                retorno.ListaOcupacaoWorkflow = gestaoOcupacaoDAO.GetListaOcupacaoWorkflow(retorno.WorkflowId);

                if (retorno.Trechos != null && retorno.Trechos.Count > 0)
                {
                    foreach (var trecho in retorno.Trechos)
                    {
                        trecho.trecho_interferencias = new List<GestaoOcupacoesTrechoInterferenciaViewModel>();

                        trecho.trecho_interferencias.AddRange(gestaoOcupacaoTrechoInterferenciaDAO.GetByTrechoId(trecho.Id));
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public GestaoOcupacaoViewModel ObtemTrechos(int id)
        {
            try
            {
                var retorno = gestaoOcupacaoDAO.GetById(id);

                retorno.Ocupacao = new GestaoOcupacaoOcupacaoViewModel();
                retorno.Parecer = new GestaoOcupacaoParecerViewModel();
                retorno.Deferimento = new GestaoOcupacaoDeferimentoViewModel();
                retorno.Documentos = new List<GestaoOcupacaoDocumentoViewModel>();
                retorno.Ocorrencias = new List<RetornoOcorrenciaViewModel>();
                retorno.Trechos = new List<GestaoOcupacoesTrechoViewModel>();

                retorno.Ocupacao = gestaoOcupacaoOcupacaoDAO.GetByOcupacaoId(id);
                retorno.Parecer = gestaoOcupacaoParecerDAO.GetByOcupacaoId(id);
                retorno.Deferimento = gestaoOcupacaoDeferimentoDAO.GetByOcupacaoId(id);
                retorno.Documentos.AddRange(gestaoOcupacaoDocumentoDAO.GetByOcupacaoId(id));
                retorno.Ocorrencias.AddRange(gestaoOcupacaoOcorrenciaDAO.GetByOcupacaoId(id));
                retorno.Trechos.AddRange(gestaoOcupacaoTrechoDAO.GetByOcupacaoId(id));

                if (retorno.Trechos != null && retorno.Trechos.Count > 0)
                {
                    foreach (var trecho in retorno.Trechos)
                    {
                        trecho.trecho_interferencias = new List<GestaoOcupacoesTrechoInterferenciaViewModel>();

                        trecho.trecho_interferencias.AddRange(gestaoOcupacaoTrechoInterferenciaDAO.GetByTrechoId(trecho.Id));
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GestaoOcupacao ObtemId(int id)
        {
            return gestaoOcupacaoDAO.Get(id);
        }

        public void Excluir(int id)
        {
            gestaoOcupacaoDAO.Excluir(id);
        }

        public GestaoOcupacaoValidatorViewModel Inserir(GestaoOcupacaoViewModel viewModel, string UsuarioAtualizacao)
        {
            try
            {
                bool update = false;

                var domain = new GestaoOcupacao()
                {
                    Id = viewModel.Id,
                    InteressadoId = viewModel.InteressadoId,
                    RegionalId = viewModel.RegionalId,
                    NumeroSPDOC = viewModel.NumeroSPDOC,
                    NumeroProcesso = viewModel.NumeroProcesso,
                    DataImplantacao = viewModel.DataImplantacao,
                    OrigemSolicitacaolId = viewModel.OrigemSolicitacaoId,
                    SituacaoSolicitacaoId = viewModel.SituacaoSolicitacaoId,
                    SituacaoOcupacaoId = viewModel.SituacaoOcupacaoId,
                    DataCadastro = viewModel.DataCadastro,
                    ResidenciaConservacaoId = viewModel.ResidenciaConservacaoId,
                    Ativo = viewModel.Ativo,
                };

                int idOcupacao = 0;

                var UsuarioId = PerfilUsuario.UsuarioId;
                if (viewModel.Id == 0)
                {
                    var workflowInserido = gestaoOcupacaoWorkflowDAO.Inserir(new GestaoOcupacaoWorkflow { DataCadastro = DateTime.Now });
                    domain.WorkflowId = workflowInserido.id;
                    domain.Sequencia = 1;
                    domain.Ativo = true;
                    domain.SituacaoSolicitacaoId = SituacaoSolicitacaoIdEnum.analise.GetHashCode();
                    idOcupacao = gestaoOcupacaoDAO.Inserir(domain, UsuarioAtualizacao, UsuarioId);
                }
                else
                {
                    //se o front manda criar uma nova solicitacao, desativar o Id anterior, e criar um novo ID
                    //a criacao de uma nova solicitacao sempre ocorre quando se clica em:
                    //Manutencao,Retificação,Transferência --> front vai mandar criarNovaOcupacao=true

                    //Para cancelamento, apenas update mesmo --> front vai mandar criarNovaOcupacao=false, e vai colocar somente leitura nas próximas vezes que carregar esse Id de ocupação ( que estará ativo, porém situação cancelado. )
                    if (viewModel.criarNovaOcupacao)
                    {
                        var GestaoOcupacaoCorrente = gestaoOcupacaoDAO.GetById(viewModel.Id);
                        gestaoOcupacaoDAO.UpdateParaInativo(viewModel.Id);
                        domain.WorkflowId = GestaoOcupacaoCorrente.WorkflowId;
                        domain.Sequencia = ++GestaoOcupacaoCorrente.Sequencia;
                        domain.Ativo = true;
                        domain.SituacaoSolicitacaoId = SituacaoSolicitacaoIdEnum.analise.GetHashCode();
                        OrigemSolicitacaoEnum origem = (OrigemSolicitacaoEnum)Enum.ToObject(typeof(OrigemSolicitacaoEnum), domain.OrigemSolicitacaolId);

                        idOcupacao = gestaoOcupacaoDAO.Inserir(domain, UsuarioAtualizacao, UsuarioId);
                    }
                    else
                    {
                        idOcupacao = viewModel.Id;
                        update = true;
                        gestaoOcupacaoDAO.Update(domain);
                    }
                }

                this.AddOcorrencias(viewModel.Ocorrencias, idOcupacao, update);

                this.AddTrechos(viewModel.Trechos, idOcupacao, update);

                this.AddDocumentos(viewModel.Documentos, idOcupacao, update);

                if (viewModel.Parecer != null && (!string.IsNullOrEmpty(viewModel.Parecer.ParecerCoordenadoriaOperacoesObservacao)
                    || !string.IsNullOrEmpty(viewModel.Parecer.ParecerDiretoriaEngenhariaObservacao)
                    || !string.IsNullOrEmpty(viewModel.Parecer.ParecerFaixaDominioObservacao)
                    || !string.IsNullOrEmpty(viewModel.Parecer.ParecerRegionalObservacao)))
                {
                    this.AddParecer(viewModel.Parecer, idOcupacao, update);
                }

                if (viewModel.Deferimento != null && !string.IsNullOrEmpty(viewModel.Deferimento.NumeroProcesso))
                {
                    this.AddDeferimento(viewModel.Deferimento, idOcupacao, update);
                    domain.SituacaoSolicitacaoId = SituacaoSolicitacaoIdEnum.deferido.GetHashCode();
                    gestaoOcupacaoDAO.Update(domain);
                }

                this.AddOcupacao(viewModel.Ocupacao, idOcupacao, update);

                this.AddCancelamento(viewModel.Cancelamento, idOcupacao, update);
                if (viewModel.Manutencao != null && !string.IsNullOrEmpty(viewModel.Manutencao.NomeArquivo))
                {
                    this.AddManutencao(viewModel.Manutencao, idOcupacao, update);
                    domain.SituacaoSolicitacaoId = SituacaoSolicitacaoIdEnum.autorizado.GetHashCode();
                    gestaoOcupacaoDAO.Update(domain);
                }

                this.AddRegularizacao(viewModel.Regularizacao, idOcupacao, update);

                this.AddRetificacao(viewModel.Retificacao, idOcupacao, update);

                this.AddTransferencia(viewModel.Transferencia, idOcupacao, update);
                
                return new GestaoOcupacaoValidatorViewModel() { id = idOcupacao, valid = true };
            }
            catch (Exception ex)
            {
                return new GestaoOcupacaoValidatorViewModel() { valid = false };
            }
        }

        #endregion


        #region Metodos Privados
        private void AddCancelamento(GestaoOcupacaoCancelamentoViewModel entitade, int idOcupacao, bool update)
        {
            try
            {
                if (entitade == null) return;
                if (update)
                {
                    gestaoOcupacaoCancelamentoDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                var domain = new GestaoOcupacaoCancelamento()
                {
                    id = entitade.id,
                    MotivoCancelamento = entitade.MotivoCancelamento,
                    GestaoOcupacaoId = idOcupacao
                };

                gestaoOcupacaoCancelamentoDAO.Inserir(domain);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void AddManutencao(GestaoOcupacaoManutencaoViewModel entitade, int idOcupacao, bool update)
        {
            try
            {
                if (entitade == null || string.IsNullOrEmpty(entitade.NomeArquivo)) return;

                if (update)
                {
                    gestaoOcupacaoManutencaoDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                var domain = new GestaoOcupacaoManutencao()
                {
                    id = entitade.id,
                    GestaoOcupacaoId = idOcupacao,
                    DataAssinatura = Convert.ToDateTime(entitade.DataAssinatura),
                    DataAprovacaoRegional = Convert.ToDateTime(entitade.DataAprovacaoRegional),
                    Observacao = entitade.Observacao,
                    CaminhoArquivo = this.SalvarArquivo(entitade.Arquivo, entitade.NomeArquivo)
                };

                gestaoOcupacaoManutencaoDAO.Inserir(domain);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void AddRegularizacao(GestaoOcupacaoRegularizacaoViewModel entitade, int idOcupacao, bool update)
        {
            try
            {
                if (entitade == null) return;
                if (update)
                {
                    gestaoOcupacaoRegularizacaoDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                var domain = new GestaoOcupacaoRegularizacao()
                {
                    id = entitade.id,
                    GestaoOcupacaoId = idOcupacao,
                    DataProvavelImplantacao = entitade.DataProvavelImplantacao,

                };

                gestaoOcupacaoRegularizacaoDAO.Inserir(domain);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void AddRetificacao(GestaoOcupacaoRetificacaoViewModel entitade, int idOcupacao, bool update)
        {
            try
            {
                if (entitade == null) return;
                if (update)
                {
                    gestaoOcupacaoRetificacaoDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                var domain = new GestaoOcupacaoRetificacao()
                {
                    id = entitade.id,
                    GestaoOcupacaoId = idOcupacao,
                    DataSolicitacao = Convert.ToDateTime(entitade.DataSolicitacao),
                    ObjetoTermoRetificacao = entitade.ObjetoTermoRetificacao,

                };

                gestaoOcupacaoRetificacaoDAO.Inserir(domain);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void AddTransferencia(GestaoOcupacaoTransferenciaViewModel entitade, int idOcupacao, bool update)
        {
            try
            {
                if (entitade == null || entitade.InteressadoAntecessorId <= 0) return;
                if (update)
                {
                    gestaoOcupacaoTransferenciaDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                var domain = new GestaoOcupacaoTransferencia()
                {
                    id = entitade.id,
                    GestaoOcupacaoId = idOcupacao,
                    InteressadoAntecessorId = entitade.InteressadoAntecessorId,
                    NumerospdocAntecessor = entitade.NumerospdocAntecessor,
                    NumeroProcessoAntecessor = entitade.NumeroProcessoAntecessor,
                    Recolher = entitade.Recolher,
                    LiminarDepositoJudicial = entitade.LiminarDepositoJudicial,
                    LiminarSuspensoRecolhimento = entitade.LiminarSuspensoRecolhimento,
                    Observacao = entitade.Observacao,
                    DataSolicitacao = Convert.ToDateTime(entitade.DataSolicitacao)
                };

                gestaoOcupacaoTransferenciaDAO.Inserir(domain);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddOcorrencias(List<RetornoOcorrenciaViewModel> ocorrencias, int idOcupacao, bool update)
        {
            try
            {
                if (update)
                {
                    gestaoOcupacaoOcorrenciaDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                if (ocorrencias != null && ocorrencias.Count > 0)
                {
                    foreach (var ocorrencia in ocorrencias)
                    {
                        var oco = new GestaoOcupacaoOcorrencia()
                        {
                            GestaoOcupacaoId = idOcupacao,
                            DataOcorrencia = ocorrencia.DataOcorrencia,
                            Autor = ocorrencia.Autor,
                            Area = ocorrencia.Area,
                            AreaId = ocorrencia.AreaId,
                            Ocorrencia = ocorrencia.Ocorrencia,
                        };

                        gestaoOcupacaoOcorrenciaDAO.Inserir(oco);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddTrechos(List<GestaoOcupacoesTrechoViewModel> trechos, int idOcupacao, bool update)
        {
            try
            {
                if (update)
                {
                    gestaoOcupacaoTrechoInterferenciaDAO.ExcluirPorIdOcupacao(idOcupacao);
                    gestaoOcupacaoTrechoDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                if (trechos != null && trechos.Count > 0)
                {
                    foreach (var trecho in trechos)
                    {
                        var tre = new GestaoOcupacaoTrecho()
                        {
                            GestaoOcupacaoId = idOcupacao,
                            KmInicial = trecho.KmInicial,
                            KmInicialMetragem = trecho.KmInicialMetragem,
                            KmFinal = trecho.KmFinal,
                            KmFinalMetragem = trecho.KmFinalMetragem,
                            Extensao = trecho.Extensao,
                            Altura = trecho.Altura,
                            LadoId = trecho.LadoId,
                            Profundidade = trecho.Profundidade
                        };

                        if (trecho.Lado != null)
                        {
                            tre.LadoId = trecho.Lado.LadoId;
                        }

                        if (trecho.Rodovia != null)
                        {
                            tre.RodoviaId = trecho.Rodovia.RodoviaId;
                        }

                        if (trecho.Localizacao != null)
                        {

                            tre.Localizacao = (trecho.Localizacao.Nome == "faixadominio") ? (int)LocalizacaoEnum.FaixaDominio : (int)LocalizacaoEnum.NonAedificandi;
                        }

                        if (trecho.TipoImplantacao != null)
                        {
                            tre.TipoImplantacaoId = trecho.TipoImplantacao.TipoImplantacaoId;
                        }

                        if (trecho.TipoPassagem != null)
                        {
                            tre.TipoPassagemId = trecho.TipoPassagem.TipoPassagemId;
                        }

                        if (trecho.TipoOcupacao != null)
                        {
                            tre.TipoOcupacaoId = trecho.TipoOcupacao.tipo_ocupacao_id;
                        }

                        var idTrecho = gestaoOcupacaoTrechoDAO.Inserir(tre);

                        this.AddInterferencias(trecho.trecho_interferencias, idTrecho);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddDocumentos(List<GestaoOcupacaoDocumentoViewModel> documentos, int idOcupacao, bool update)
        {
            try
            {
                if (update)
                {
                    gestaoOcupacaoDocumentoDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                if (documentos != null && documentos.Count > 0)
                {
                    foreach (var documento in documentos)
                    {
                        var doc = new GestaoOcupacaoDocumento()
                        {
                            GestaoOcupacaoId = idOcupacao,
                            TipoDocumentoId = documento.TipoDocumentoId,
                            Documento = documento.Documento,
                            Arquivo = this.SalvarArquivo(documento.Arquivo, documento.ArquivoNome),
                            AdicionadoPor = documento.AdicionadoPor,
                            //DataAdicionado = (documento.DataAdicionado == Convert.ToDateTime("01/01/0001 00:00:00")) ? DateTime.Now : documento.DataAdicionado.Value
                            DataAdicionado = DateTime.Now
                        };

                        gestaoOcupacaoDocumentoDAO.Inserir(doc);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddParecer(GestaoOcupacaoParecerViewModel parecer, int idOcupacao, bool update)
        {
            try
            {
                if (update)
                {
                    gestaoOcupacaoParecerDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                var domain = new GestaoOcupacaoParecer()
                {
                    GestaoOcupacaoId = idOcupacao,
                    ParecerRegionalId = parecer.ParecerRegionalId,
                    ParecerRegionalObservacao = parecer.ParecerRegionalObservacao,
                    ParecerDiretoriaEngenhariaId = parecer.ParecerDiretoriaEngenhariaId,
                    ParecerDiretoriaEngenhariaObservacao = parecer.ParecerDiretoriaEngenhariaObservacao,
                    ParecerCoordenadoriaOperacoesId = parecer.ParecerCoordenadoriaOperacoesId,
                    ParecerCoordenadoriaOperacoesObservacao = parecer.ParecerCoordenadoriaOperacoesObservacao,
                    ParecerFaixaDominioId = parecer.ParecerFaixaDominioId,
                    ParecerFaixaDominioObservacao = parecer.ParecerFaixaDominioObservacao,
                    Data = DateTime.Now,
                    ParecerRegionalDocumentoArquivo = this.SalvarArquivo(parecer.ParecerRegionalDocumentoArquivo, parecer.ParecerRegionalDocumentoNome),
                    ParecerDiretoriaDocumentoArquivo = this.SalvarArquivo(parecer.ParecerDiretoriaDocumentoArquivo, parecer.ParecerDiretoriaDocumentoNome),
                    ParecerCoordenadoriaDocumentoArquivo = this.SalvarArquivo(parecer.ParecerCoordenadoriaDocumentoArquivo, parecer.ParecerCoordenadoriaDocumentoNome),
                    ParecerFaixaDominioDocumentoArquivo = this.SalvarArquivo(parecer.ParecerFaixaDominioDocumentoArquivo, parecer.ParecerFaixaDominioDocumentoNome)
                };

                if (parecer.ParecerCoordenadoriaOperacoesData != Convert.ToDateTime("01/01/0001 00:00:00"))
                {
                    domain.ParecerCoordenadoriaOperacoesData = parecer.ParecerCoordenadoriaOperacoesData;
                }

                if (parecer.ParecerRegionalData != Convert.ToDateTime("01/01/0001 00:00:00"))
                {
                    domain.ParecerRegionalData = parecer.ParecerRegionalData;
                }

                if (parecer.ParecerDiretoriaEngenhariaData != Convert.ToDateTime("01/01/0001 00:00:00"))
                {
                    domain.ParecerDiretoriaEngenhariaData = parecer.ParecerDiretoriaEngenhariaData;
                }

                if (parecer.ParecerFaixaDominioData != Convert.ToDateTime("01/01/0001 00:00:00"))
                {
                    domain.ParecerFaixaDominioData = parecer.ParecerFaixaDominioData;
                }

                gestaoOcupacaoParecerDAO.Inserir(domain);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddDeferimento(GestaoOcupacaoDeferimentoViewModel deferimento, int idOcupacao, bool update)
        {
            try
            {
                if (update)
                {
                    gestaoOcupacaoDeferimentoDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                var domain = new GestaoOcupacaoDeferimento()
                {
                    GestaoOcupacaoId = idOcupacao,
                    NumeroProcesso = deferimento.NumeroProcesso,
                    TermoAnexadoArquivo = this.SalvarArquivo(deferimento.TermoAnexadoArquivo, deferimento.TermoAnexadoNome)
                };

                if (deferimento.DataDespachoAutorizativo != Convert.ToDateTime("01/01/0001 00:00:00"))
                {
                    domain.DataDespachoAutorizativo = deferimento.DataDespachoAutorizativo;
                }

                if (deferimento.DataAssinatura != Convert.ToDateTime("01/01/0001 00:00:00"))
                {
                    domain.DataAssinatura = deferimento.DataAssinatura;
                }

                if (deferimento.DataPublicacao != Convert.ToDateTime("01/01/0001 00:00:00"))
                {
                    domain.DataPublicacao = deferimento.DataPublicacao;
                }

                gestaoOcupacaoDeferimentoDAO.Inserir(domain);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddOcupacao(GestaoOcupacaoOcupacaoViewModel ocupacao, int idOcupacao, bool update)
        {
            try
            {
                if (update)
                {
                    gestaoOcupacaoOcupacaoDAO.ExcluirPorIdOcupacao(idOcupacao);
                }

                gestaoOcupacaoOcupacaoDAO.Inserir(new GestaoOcupacaoOcupacao()
                {
                    GestaoOcupacaoId = idOcupacao,
                    Assunto = ocupacao.Assunto,
                    Observacao = ocupacao.Observacao,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddInterferencias(List<GestaoOcupacoesTrechoInterferenciaViewModel> interferencias, int idTrecho)
        {
            try
            {
                if (interferencias != null && interferencias.Count > 0)
                {
                    foreach (var interferencia in interferencias)
                    {
                        gestaoOcupacaoTrechoInterferenciaDAO.Inserir(new GestaoOcupacaoTrechoInterferencia()
                        {
                            GestaoOcupacaoTrechoId = idTrecho,
                            TipoInterferencia = interferencia.interferencia_tipo_id,
                            Quantidade = interferencia.quantidade,
                            Volume = interferencia.volume_unitario,
                            VolumeTotal = interferencia.volume_total
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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