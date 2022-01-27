using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAO;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Domain.Models;
using DER.WebApp.Models.Enum;

namespace DER.WebApp.Controllers
{
    [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcupacoesCodigo)]
    public class GestaoOcupacoesController : HelperController
    {

        string DiretorioRegulamento = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["DiretorioRegulamento"]);  // padrão de localização de arquivos no Web.Config
        string DiretorioNorma = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["DiretorioNorma"]);  // padrão de localização de arquivos  no Web.Config

        List<ProjetosMelhoriasRegionalViewModel> _ObtemRegionais = new List<ProjetosMelhoriasRegionalViewModel>();
        List<GestaoOcupacoesResidenciaConservacaoViewModel> _ObtemResidenciaConservacoes = new List<GestaoOcupacoesResidenciaConservacaoViewModel>();
        List<GestaoOcupacoesOrigemSolicitacaoViewModel> _ObtemOrigemSolicitacoes = new List<GestaoOcupacoesOrigemSolicitacaoViewModel>();
        List<GestaoOcupacoesSituacaoSolicitacaoViewModel> _ObtemSituacaoSolicitacoes = new List<GestaoOcupacoesSituacaoSolicitacaoViewModel>();
        List<GestaoOcupacoesSituacaoOcupacaoViewModel> _ObtemSituacaoOcupacoes = new List<GestaoOcupacoesSituacaoOcupacaoViewModel>();
        List<ViewModels.ProjetosMelhorias.RodoviaViewModel> _ObtemRodovias = new List<ViewModels.ProjetosMelhorias.RodoviaViewModel>();
        List<GestaoOcupacoesTipoImplantacaoViewModel> _ObtemTipoImplantacoes = new List<GestaoOcupacoesTipoImplantacaoViewModel>();
        List<GestaoOcupacoesTipoPassagemViewModel> _ObtemTipoPassagens = new List<GestaoOcupacoesTipoPassagemViewModel>();
        List<TipoOcupacaoViewModel> _ObtemTipoOcupacoes = new List<TipoOcupacaoViewModel>();
        List<LadoViewModel> _ObtemLados = new List<LadoViewModel>();
        List<TipoDeInterferenciaViewModel> _ObtemTipoDeInterferencias = new List<TipoDeInterferenciaViewModel>();
        List<GestaoOcupacoesMunicipioViewModel> _ObtemMunicipio = new List<GestaoOcupacoesMunicipioViewModel>();
        List<EstadoViewModel> _ObtemEstado = new List<EstadoViewModel>();
        List<ViewModels.GestaoInteressados.TipoInteressadoViewModel> _ObtemTipoInteressado = new List<ViewModels.GestaoInteressados.TipoInteressadoViewModel>();
        List<NaturezaJuridicaViewModel> _ObtemNaturezaJuridica = new List<NaturezaJuridicaViewModel>();
        List<AreaViewModel> _ObtemAreas = new List<AreaViewModel>();
        string _DisponibilizarArquivoRegulamento = "";
        string _DisponibilizarArquivoNorma = "";
        List<TipoDeDocumentoOcupacaoViewModel> _ObtemTipoDeDocumentosOcupacao = new List<TipoDeDocumentoOcupacaoViewModel>();

        #region Construtor

        private GestaoOcupacaoBLL gestaoOcupacaoBLL;
        private GestaoInteressadoBLL gestaoInteressadoBLL;
        private ProjetosMelhoriasBLL projetosMelhoriasBLL;
        private MunicipioGestaoOcupacaoBLL municipioBLL;
        private RodoviaBLL rodoviaBLL;
        private DispositivoBLL dispositivoBLL;
        private RegionalProjetosMelhoriasBLL regionalBLL;
        private TipoInteressadoBLL tipoInteressadoBLL;
        private NaturezaJuridicaBLL naturezaJuridicaBLL;
        private TipoDeDocumentoBLL tipoDeDocumentoBLL;
        private AreaBLL areaBLL;
        private TipoDePassagemBLL tipoDePassagemBLL;
        private TipoDeOcupacaoBLL tipoDeOcupacaoBLL;
        private SituacaoDaSolicitacaoBLL situacaoDaSolicitacaoBLL;
        private SituacaoDaOcupacaoBLL situacaoDaOcupacaoBLL;
        private OrigemDaSolicitacaoBLL origemDaSolicitacaoBLL;
        private ResidenciaConservacoesBLL residenciaConservacoesBLL;
        private TipoDeImplantacaoBLL tipoDeImplantacaoBLL;
        private UnidadeGestaoOcupacaoBLL unidadeBLL;
        private LadoBLL ladoBLL;
        private TipoDeInterferenciaBLL tipoDeInterferenciaBLL;
        private TipoDeDocumentoOcupacaoBLL tipoDeDocumentoOcupacaoBLL;
        private TipoOcupacoesBLL tipoOcupacoesBLL;
        private BancoBrasilBoletoBLL bancoBrasilBoletoBLL;
        private GestaoOcupacaoPEPBLL gestaoOcupacaoPEPBLL;
        private GestaoOcupacaoRemuneracaoBLL gestaoOcupacaoRemuneracaoBLL;
        private GestaoOcupacaoAcoesJudiciaisBLL gestaoOcupacaoAcoesJudiciaisBLL;
        private Logger logger;

        public GestaoOcupacoesController()
        {
            gestaoOcupacaoBLL = new GestaoOcupacaoBLL();
            gestaoInteressadoBLL = new GestaoInteressadoBLL();
            projetosMelhoriasBLL = new ProjetosMelhoriasBLL();
            municipioBLL = new MunicipioGestaoOcupacaoBLL();
            rodoviaBLL = new RodoviaBLL();
            regionalBLL = new RegionalProjetosMelhoriasBLL();
            tipoInteressadoBLL = new TipoInteressadoBLL();
            naturezaJuridicaBLL = new NaturezaJuridicaBLL();
            tipoDeDocumentoBLL = new TipoDeDocumentoBLL();
            areaBLL = new AreaBLL();
            tipoDePassagemBLL = new TipoDePassagemBLL();
            tipoDeOcupacaoBLL = new TipoDeOcupacaoBLL();
            situacaoDaSolicitacaoBLL = new SituacaoDaSolicitacaoBLL();
            situacaoDaOcupacaoBLL = new SituacaoDaOcupacaoBLL();
            origemDaSolicitacaoBLL = new OrigemDaSolicitacaoBLL();
            residenciaConservacoesBLL = new ResidenciaConservacoesBLL();
            tipoDeImplantacaoBLL = new TipoDeImplantacaoBLL();
            unidadeBLL = new UnidadeGestaoOcupacaoBLL();
            ladoBLL = new LadoBLL();
            tipoDeInterferenciaBLL = new TipoDeInterferenciaBLL();
            tipoDeDocumentoOcupacaoBLL = new TipoDeDocumentoOcupacaoBLL();
            tipoOcupacoesBLL = new TipoOcupacoesBLL();
            bancoBrasilBoletoBLL = new BancoBrasilBoletoBLL();
            gestaoOcupacaoPEPBLL = new GestaoOcupacaoPEPBLL();
            gestaoOcupacaoRemuneracaoBLL = new GestaoOcupacaoRemuneracaoBLL();
            gestaoOcupacaoAcoesJudiciaisBLL = new GestaoOcupacaoAcoesJudiciaisBLL();
            logger = new Logger("Gestão Ocupações");
        }


        #endregion

        #region Metodos Publicos

        [AuthorizeCustom(Roles = Permissoes.GestaoOcupacoesCodigo)]
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.GestaoOcupacoesCodigo);
            var UsuarioIdSessao = PerfilUsuario.UsuarioId;
            var UsuarioEmpresaId = PerfilUsuario.UsuarioEmpresaId;
            var UsuarioPerfilId = PerfilUsuario.UsuarioPerfilId;

            if (UsuarioPerfilId == 23)
            {
                UsuarioPerfilId = 1;
                UsuarioIdSessao = 0;
                UsuarioEmpresaId = 0;
            }
            var gestaoOcupacoes = gestaoOcupacaoBLL.GetListGestaoOcupacao(UsuarioPerfilId, UsuarioEmpresaId, UsuarioIdSessao);
            return View(gestaoOcupacoes);
        }

        [HttpGet]
        public JsonResult ListRodovias()
        {
            obtemPermissoes(Permissoes.GestaoOcupacoesCodigo);
            var rodovias = rodoviaBLL.ObtemRodovia();
            return Json(rodovias, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListRegionais()
        {
            obtemPermissoes(Permissoes.GestaoOcupacoesCodigo);
            var regionais = regionalBLL.ObtemRegionais();
            return Json(regionais, JsonRequestBehavior.AllowGet);
        }

        // [AuthorizeCustom(Roles = Permissoes.GestaoOcupacoesCodigo)]
        [HttpGet]
        public JsonResult ListOcupacao()
        {
            obtemPermissoes(Permissoes.GestaoOcupacoesCodigo);
            List<GestaoOcupacaoViewModel> gestaoOcupacoes = gestaoOcupacaoBLL.GetListGestaoOcupacaoComTrecho();
            return Json(gestaoOcupacoes, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcupacoesCodigo + Permissoes.CadastrarCodigo)]
        public ActionResult Novo(bool regularizacao)
        {
            DisponibilizarArquivoRegulamento();
            DisponibilizarArquivoNorma();
            ViewData["SomenteVisualizar"] = false;            

            var retorno = this.RetornaViewModelNovo();
            if (!regularizacao)
            {
                retorno.OrigemSolicitacaoId = Convert.ToInt32(retorno.OrigemSolicitacoes.Where(n => n.Text == "Solicitação de Implantação").FirstOrDefault().Value);
            }
            else
            {
                retorno.OrigemSolicitacaoId = Convert.ToInt32(retorno.OrigemSolicitacoes.Where(n => n.Text.Contains("Regularização")).FirstOrDefault().Value);
            }

            ViewBag.novo = true;
            return View(retorno);
        }


        [HttpGet]
        public JsonResult NovoVersionamento(int id)//TRAVAR NO 195 
        {
            DisponibilizarArquivoRegulamento();
            DisponibilizarArquivoNorma();
            ViewData["SomenteVisualizar"] = false;
            var model = this.RetornaViewModelNovo(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcupacoesCodigo + Permissoes.EditarCodigo)]
        public ActionResult Editar(int id, string novaOrigem = null)
        {
            DisponibilizarArquivoRegulamento();
            DisponibilizarArquivoNorma();
            ViewData["SomenteVisualizar"] = false;
            ViewData["novaOrigem"] = novaOrigem;
            var model = this.RetornaViewModelNovo(id);


            model.ListaGestaoOcupacoesViewModel = new List<GestaoOcupacoesViewModel>();
            foreach (var item in model.ListaOcupacaoWorkflow)
            {
                model.ListaGestaoOcupacoesViewModel.Add(this.RetornaViewModelNovo(item.OcupacaoId));
            }

            //222 1   Solicitação de Implantação  33
            //246 2   Solicitação de Cancelamento 33
            //247 3   Transferência de Titularidade   33
            //221446  4   Regularização   33
            //221447  5   Ajuizamento de Ação 33
            //221448  6   Manutenção de Rotina    33
            //221449  7   Retificação 33

            var myEnumByDescription = EnumUtility.GetEnumValueFromDescription<OrigemSolicitacaoEnum>(novaOrigem);
            switch (myEnumByDescription)
            {
                case OrigemSolicitacaoEnum.retificacao:
                case OrigemSolicitacaoEnum.cancelamento:
                case OrigemSolicitacaoEnum.manutencao:
                case OrigemSolicitacaoEnum.transferencia:
                case OrigemSolicitacaoEnum.ajuizamento:
                case OrigemSolicitacaoEnum.regularizacao:
                    model.ListaDocumentos = new List<ViewModels.GestaoOcupacoes.GestaoDocumentoViewModel>();
                    model.ListaOcorrencias = new List<GestaoOcupacoesOcorrenciaViewModel>();
                    model.Deferimento = new GestaoOcupacoesDeferimentoViewModel();
                    model.Remuneracao = new List<GestaoOcupacoesRemuneracaoViewModel>();
                    model.PEP = new GestaoOcupacoesPEPViewModel();
                    model.Retificacao = new GestaoOcupacaoRetificacaoViewModel();
                    model.Cancelamento = new GestaoOcupacaoCancelamentoViewModel();
                    model.Manutencao = new GestaoOcupacaoManutencaoViewModel();
                    model.Transferencia = new GestaoOcupacaoTransferenciaViewModel();
                    model.AcoesJudiciais = new GestaoOcupacoesAcoesJudiciaisViewModel();
                    model.Regularizacao = new GestaoOcupacaoRegularizacaoViewModel();
                    model.OrigemSolicitacaoId = myEnumByDescription.GetHashCode();
                    model.CriarNovaOcupacao = true;
                    model.SituacaoSolicitacaoId = SituacaoSolicitacaoIdEnum.analise.GetHashCode();
                    model.DataSolicitacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");


                    if (myEnumByDescription == OrigemSolicitacaoEnum.transferencia)
                    {
                        //troca de antecessor para sucessor
                        model.Transferencia = new GestaoOcupacaoTransferenciaViewModel();
                        model.Transferencia.InteressadoAntecessorId = model.InteressadoId;
                        model.Transferencia.AntecessorInteressado = model.Interessado;
                        model.Transferencia.AntecessorInteressadoEmail = model.InteressadoEmail;
                        model.Transferencia.NumeroProcessoAntecessor = model.NumeroProcesso;
                        model.Transferencia.NumerospdocAntecessor = model.NumeroSPDOC;
                        model.Transferencia.AntecessorDocumento = model.CpfCNPJ;

                        model.InteressadoId = 0;
                        model.Interessado = "";
                        model.InteressadoEmail = "";
                        model.NumeroProcesso = "";
                        model.NumeroSPDOC = "";
                        model.CpfCNPJ = "";

                    }
                    break;

                default:
                    model.CriarNovaOcupacao = false;
                    break;
            }
            ViewBag.novo = false;
            return View("Novo", model);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcupacoesCodigo + Permissoes.VisualizarCodigo)]
        public ActionResult Visualizar(int id)
        {
            DisponibilizarArquivoRegulamento();
            DisponibilizarArquivoNorma();
            ViewData["SomenteVisualizar"] = true;
            var model = this.RetornaViewModelNovo(id);
            model.ListaGestaoOcupacoesViewModel = new List<GestaoOcupacoesViewModel>();
            foreach (var item in model.ListaOcupacaoWorkflow)
            {
                model.ListaGestaoOcupacoesViewModel.Add(this.RetornaViewModelNovo(item.OcupacaoId));
            }
            return View("Novo", model);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcupacoesCodigo + Permissoes.ExcluirCodigo)]
        public ActionResult Excluir(int id)
        {
            try
            {
                gestaoOcupacaoBLL.Excluir(id);
                logger.salvarLog(TipoAlteracao.Exclusao, id.ToString(), null,gestaoOcupacaoBLL.ObtemId(id));
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return Json(new { status = false });
            }
        }


        [HttpPost]
        public async Task<ActionResult> Salvar(GestaoOcupacaoViewModel viewModel)
        {
            ViewBag.Usuario = User.Identity.Name.ToString();
            var valid = gestaoOcupacaoBLL.Inserir(viewModel, ViewBag.Usuario);

            if (valid.valid)
                logger.salvarLog(viewModel.Id == 0 ? TipoAlteracao.Criacao : TipoAlteracao.Edicao, valid.id.ToString(), gestaoOcupacaoBLL.ObtemId(valid.id));

            return Json(valid);
        }

        public JsonResult ConsultarInteressado(InteressadoOcupacaoParansDTO viewModel)
        {
            ViewBag.Usuario = User.Identity.Name.ToString();
            return Json(gestaoOcupacaoBLL.GetInteressadoByParams(viewModel, ViewBag.Usuario));
        }

        public JsonResult ValidacaoTrechoProjetoMelhoria(ValidacaoTrechoProjetoViewModel viewModel)
        {
            return Json(projetosMelhoriasBLL.ValidacaoTrechoProjetoMelhoria(viewModel));
        }

        public JsonResult ConsultarTipoOperacao(int idInteressado)
        {
            return Json(tipoDeOcupacaoBLL.ObtemTipoOcupacoes(idInteressado));
        }

        [HttpGet()]
        public FileResult DownloadArquivo(string caminhoArquivo)
        {
            var extensao = (caminhoArquivo.Contains(".pdf")) ? ".pdf" : ".jpg";
            string contentType = (caminhoArquivo.Contains(".pdf")) ? "application/pdf" : "image/jpg";
            string nomeArquivo = DateTime.Now.ToString("yyyyMMddHHmmss") + extensao;

            return File("C:/der/arquivos/" + caminhoArquivo, contentType, nomeArquivo);
        }

        //AQUI
        [HttpPost]
        public ActionResult CalcularPEP(int IdOcupacao)
        {
            try
            {
                gestaoOcupacaoRemuneracaoBLL.Write(RetornaViewModelNovo(IdOcupacao));
                return Json(gestaoOcupacaoPEPBLL.Write(RetornaViewModelNovo(IdOcupacao)));
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }

        public FileResult BaixarBoletoPEP(int idocupacao)
        {
            try
            {
                var model = RetornaViewModelNovo(idocupacao);
                var valor = model.PEP.Valor;
                var data = model.PEP.DataEmissãoPEP;
                var file = bancoBrasilBoletoBLL.GerarBoleto(model.Id, valor, (DateTime)data, model.PEP.Id_PEP);
                if (!file[0].Equals(0))
                {
                    return File(file, "application/pdf", "boleto.pdf");
                }
                else
                    throw new System.Exception("Seu Boleto Venceu. Entre em contato com o DER-SP.");
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Boleto") || e.Message.Contains("Dados"))
                    throw new System.Exception(e.Message);
                else
                    throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }

        public ActionResult LiberarBoletoRemuneracao(int idocupacao, int idremuneracao)
        {
            try
            {
                if (idocupacao > 0)
                {
                    gestaoOcupacaoRemuneracaoBLL.LiberarBoletoRemuneracao(idocupacao, idremuneracao);
                    return Editar(idocupacao);
                }
                return List();
            }
            catch (Exception e)
            {
                if (idocupacao > 0)
                    return Editar(idocupacao);
                return List();
            }
        }

        public FileResult BaixarBoletoRemuneracao(int idocupacao, int idremuneracao, bool Liberado)
        {
            try
            {
                if (Liberado)
                {
                    var model = RetornaViewModelNovo(idocupacao);
                    var valor = model.Remuneracao.Where(x => x.IdGestaoOcupacoesRemuneracao.Equals(idremuneracao)).Select(x => x.ValorRemuneracao).FirstOrDefault();
                    var data = model.Remuneracao.Where(x => x.IdGestaoOcupacoesRemuneracao.Equals(idremuneracao)).Select(x => x.DataRemuneracao).FirstOrDefault();
                    var file = bancoBrasilBoletoBLL.GerarBoleto(model.Id, valor, (DateTime)data, idremuneracao, true);
                    if (!file[0].Equals(0))
                    {
                        return File(file, "application/pdf", "boleto.pdf");
                    }
                    else
                        throw new System.Exception("Seu Boleto Venceu. Entre em contato com o DER-SP.");
                }
                else
                    throw new System.Exception("Aguardando liberação do DER-SP");
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Boleto") || e.Message.Contains("Dados"))
                    throw new System.Exception(e.Message);
                else
                    throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }

        public ActionResult AtualizarBoletoRemuneracao(int idocupacao, int idremuneracao)
        {
            try
            {
                if (idocupacao > 0)
                {
                    gestaoOcupacaoRemuneracaoBLL.Write(RetornaViewModelNovo(idocupacao), idremuneracao);
                    return Editar(idocupacao);
                }
                return List();
            }
            catch (Exception e)
            {
                if (idocupacao > 0)
                    return Editar(idocupacao);
                throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }

        public ActionResult SalvarAcoesJudiciais(GestaoOcupacoesViewModel model)
        {
            try
            {
                logger.salvarLog(TipoAlteracao.Edicao, model.Id.ToString(), model);
                return gestaoOcupacaoAcoesJudiciaisBLL.Write(model.AcoesJudiciais) ? Editar(model.Id) : List();
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }

        #endregion

        #region Metodos Privados

        public ActionResult RetornaNaturezaJuridica(int? id)
        {
            var lista = ObtemTipoDeDocumento(id);
            return Json(new { status = true, lista = lista });
        }

        public JsonResult SalvarArquivo(List<GestaoOcupacaoDocumentoViewModel> viewModel)
        {
            //gestaoOcupacaoBLL.AddDocumentos(viewModel);
            return null;
        }

        private GestaoOcupacoesViewModel RetornaViewModelNovo(int? id = null)
        {
            if (_ObtemRegionais.Count == 0) _ObtemRegionais = ObtemRegionais();
            if (_ObtemResidenciaConservacoes.Count == 0) _ObtemResidenciaConservacoes = ObtemResidenciaConservacoes();
            if (_ObtemOrigemSolicitacoes.Count == 0) _ObtemOrigemSolicitacoes = ObtemOrigemSolicitacoes();
            if (_ObtemSituacaoSolicitacoes.Count == 0) _ObtemSituacaoSolicitacoes = ObtemSituacaoSolicitacoes();
            if (_ObtemSituacaoOcupacoes.Count == 0) _ObtemSituacaoOcupacoes = ObtemSituacaoOcupacoes();
            if (_ObtemRodovias.Count == 0) _ObtemRodovias = ObtemRodovias();
            if (_ObtemTipoImplantacoes.Count == 0) _ObtemTipoImplantacoes = ObtemTipoImplantacoes();
            if (_ObtemTipoPassagens.Count == 0) _ObtemTipoPassagens = ObtemTipoPassagens();
            if (_ObtemTipoOcupacoes.Count == 0) _ObtemTipoOcupacoes = ObtemTipoOcupacoes();
            if (_ObtemLados.Count == 0) _ObtemLados = ObtemLados();
            if (_ObtemTipoDeInterferencias.Count == 0) _ObtemTipoDeInterferencias = ObtemTipoDeInterferencias();
            if (_ObtemMunicipio.Count == 0) _ObtemMunicipio = ObtemMunicipio();
            if (_ObtemEstado.Count == 0) _ObtemEstado = ObtemEstado();
            if (_ObtemTipoInteressado.Count == 0) _ObtemTipoInteressado = ObtemTipoInteressado();
            if (_ObtemNaturezaJuridica.Count == 0) _ObtemNaturezaJuridica = ObtemNaturezaJuridica();
            if (_ObtemAreas.Count == 0) _ObtemAreas = ObtemAreas();
            if (string.IsNullOrEmpty(_DisponibilizarArquivoRegulamento)) _DisponibilizarArquivoRegulamento = DisponibilizarArquivoRegulamento();
            if (string.IsNullOrEmpty(_DisponibilizarArquivoNorma)) _DisponibilizarArquivoNorma = DisponibilizarArquivoNorma();
            if (_ObtemTipoDeDocumentosOcupacao.Count == 0) _ObtemTipoDeDocumentosOcupacao = ObtemTipoDeDocumentosOcupacao();

            var retorno = new GestaoOcupacoesViewModel();
            retorno.Deferimento = new GestaoOcupacoesDeferimentoViewModel();
            if (id != null)
            {
                retorno = ObtemGestaoOcupacao((int)id);
            }
            else
            {
                id = 0;
            }
            retorno.PEP = gestaoOcupacaoPEPBLL.Read((int)id, true).FirstOrDefault();
            retorno.Remuneracao = gestaoOcupacaoRemuneracaoBLL.Read((int)id, true);
            retorno.AcoesJudiciais = gestaoOcupacaoAcoesJudiciaisBLL.Read((int)id, true).FirstOrDefault();
            retorno.TipoOcupacoes = ObtemTipoOcupacoes();
            retorno.Regulamento = DisponibilizarArquivoRegulamento();
            retorno.Norma = DisponibilizarArquivoNorma();
            retorno.Rodovia = ObtemRodovias().Where(x => x.RodoviaId.Equals(retorno.RodoviaId)).Select(x => x.Nome).FirstOrDefault();
            retorno.TipoOcupacao = retorno.TipoOcupacoes.Where(x => x.tipo_ocupacao_id.Equals(retorno.TipoOcupacaoId)).Select(x => x.nome).FirstOrDefault();
            retorno.Regionais = new SelectList(ObtemRegionais(), "RegionalId", "Nome");
            retorno.ResidenciaConservacoes = new SelectList(ObtemResidenciaConservacoes(), "ResidenciaConservacaoId", "Nome");
            retorno.OrigemSolicitacoes = new SelectList(ObtemOrigemSolicitacoes(), "OrigemSolicitacaoId", "Nome");
            retorno.SituacaoSolitacoes = new SelectList(ObtemSituacaoSolicitacoes(), "SituacaoSolicitacaoId", "Nome");
            retorno.SituacaoOcupacoes = new SelectList(ObtemSituacaoOcupacoes(), "SituacaoOcupacaoId", "Nome");
            retorno.Interessados = new SelectList(ObtemInteressados(), "Id", "Interessado");
            retorno.Rodovias = new SelectList(ObtemRodovias(), "RodoviaId", "Nome");
            retorno.TipoImplantacoes = new SelectList(ObtemTipoImplantacoes(), "TipoImplantacaoId", "Nome");
            retorno.TipoPassagens = new SelectList(ObtemTipoPassagens(), "TipoPassagemId", "Nome");
            retorno.TipoOcupacoesSelectList = new SelectList(retorno.TipoOcupacoes, "TipoOcupacaoId", "Nome");
            retorno.Lados = new SelectList(ObtemLados(), "LadoId", "Nome");
            retorno.TipoInterferencias = new SelectList(ObtemTipoDeInterferencias(), "TipoDeInterferenciaId", "Nome");
            retorno.Municipios = new SelectList(ObtemMunicipio(), "MunicipioId", "Nome");
            retorno.Estados = new SelectList(ObtemEstado(), "EstadoId", "Nome");
            retorno.TiposInteressados = new SelectList(ObtemTipoInteressado(), "TipoInteressadoId", "Nome");
            retorno.NaturezasJuridicas = new SelectList(ObtemNaturezaJuridica(), "NaturezaJuridicaId", "Nome");
            retorno.Areas = new SelectList(ObtemAreas(), "AreaId", "Nome");
            retorno.TipoDocumentosOcupacoes = new SelectList(ObtemTipoDeDocumentosOcupacao(), "TipoDeDocumentoOcupacaoId", "Nome");

            ViewBag.Usuario = User.Identity.Name.ToString();
            ViewBag.DataAtual = DateTime.Now.ToString("dd/MM/yyyy");
            ViewBag.DataAtualizacao = DateTime.Now.ToString("dd/MM/yyyy"); //Aqui deve ser passado a data de atualzacao do objeto
            ViewBag.IsUsuarioAdm = User.Identity.Name.Equals("Admin") ? true : false;
            ViewData["PermissaoAprovacao"] = User.IsInRole(Permissoes.GestaoOcupacoesCodigo + Permissoes.AprovarCodigo);
            ViewData["DateTimeNow"] = DateTime.Now;
            ViewData["IsUsuarioAdm"] = User.IsInRole(Permissoes.UsuarioInternoCodigo);

            return retorno;
        }

        public string DisponibilizarArquivoRegulamento() // padrão de localização de arquivos  no Web.Config
        {
            string arquivo = Directory.GetFiles(DiretorioRegulamento).FirstOrDefault();
            return Path.GetFileName(arquivo);
        }

        public string DisponibilizarArquivoNorma() // padrão de localização de arquivos  no Web.Config
        {
            string arquivo = Directory.GetFiles(DiretorioNorma).FirstOrDefault();
            return Path.GetFileName(arquivo);
        }

        public FileResult DownloadRegulamentoNorma(string fileName) // padrão de localização de arquivos  no Web.Config
        {
            if (!String.IsNullOrEmpty(fileName))
            {
                string path = null;
                if (fileName.Contains("Regulamento"))
                {
                    path = DiretorioRegulamento + fileName;
                }
                else
                {
                    path = DiretorioNorma + fileName;
                }
                //Read the File data into Byte Array.
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                //Send the File to Download.
                return File(bytes, "application/octet-stream", fileName);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]

        public GestaoOcupacoesViewModel ObtemGestaoOcupacao(int id)
        {
            var viewModel = gestaoOcupacaoBLL.ObtemInfoId(id);
            var _context = new DerContext();
            var gestaoInteressadoTipoDeConcessaoDAO = new GestaoInteressadoTipoDeConcessaoDAO(_context);
            var tipoDeConcessaoViewModelList = gestaoInteressadoTipoDeConcessaoDAO.GetByGestaoId(viewModel.InteressadoId);

            var retorno = new GestaoOcupacoesViewModel()
            {
                Id = viewModel.Id,
                Interessado = viewModel.Interessado,
                InteressadoId = viewModel.InteressadoId,
                InteressadoEmail = viewModel.InteressadoEmail,
                InteressadoTipoDeConcessoes = tipoDeConcessaoViewModelList,
                RegionalId = (viewModel.RegionalId != null) ? (int)viewModel.RegionalId : 0,
                ResidenciaConservacaoId = (viewModel.ResidenciaConservacaoId != null) ? (int)viewModel.ResidenciaConservacaoId : 0,
                RodoviaId = (viewModel.RodoviaId != null) ? (int)viewModel.RodoviaId : 0,
                DataSolicitacao = (viewModel.DataCadastro != null) ? ((DateTime)viewModel.DataCadastro).ToString("yyyy-MM-dd") : string.Empty,
                NumeroSPDOC = viewModel.NumeroSPDOC,
                NumeroProcesso = viewModel.NumeroProcesso,
                DataImplantacao = (viewModel.DataImplantacao != null) ? ((DateTime)viewModel.DataImplantacao).ToString("yyyy-MM-dd") : string.Empty,
                OrigemSolicitacaoId = viewModel.OrigemSolicitacaoId,
                SituacaoSolicitacaoId = viewModel.SituacaoSolicitacaoId,
                SituacaoOcupacaoId = viewModel.SituacaoOcupacaoId,
                DataCadastro = (viewModel.DataCadastro != null) ? ((DateTime)viewModel.DataCadastro).ToString("yyyy-MM-dd") : string.Empty,
                ListaOcupacaoWorkflow = viewModel.ListaOcupacaoWorkflow.Where(o => o.OcupacaoId != id).ToList(),
                Cancelamento = viewModel.Cancelamento,
                Manutencao = viewModel.Manutencao,
                Regularizacao = viewModel.Regularizacao,
                Retificacao = viewModel.Retificacao,
                Transferencia = viewModel.Transferencia,
                Sequencia = viewModel.Sequencia,
                Ativo = viewModel.Ativo
            };


            if (viewModel.Parecer != null)
            {
                retorno.ParecerRegionalId = viewModel.Parecer.ParecerRegionalId;
                retorno.ParecerRegionalObservacao = viewModel.Parecer.ParecerRegionalObservacao;
                retorno.ParecerRegionalData = viewModel.Parecer.ParecerRegionalData.ToString("yyyy-MM-dd");
                retorno.DocumentoUploadRegional = viewModel.Parecer.ParecerRegionalDocumentoArquivo;
                retorno.ParecerDiretoriaEngenhariaId = viewModel.Parecer.ParecerDiretoriaEngenhariaId;
                retorno.ParecerDiretoriaEngenhariaObservacao = viewModel.Parecer.ParecerDiretoriaEngenhariaObservacao;
                retorno.ParecerDiretoriaEngenhariaData = viewModel.Parecer.ParecerDiretoriaEngenhariaData.ToString("yyyy-MM-dd");
                retorno.DocumentoUploadEngenharia = viewModel.Parecer.ParecerDiretoriaDocumentoArquivo;
                retorno.ParecerCoordenadoriaOperacoesId = viewModel.Parecer.ParecerCoordenadoriaOperacoesId;
                retorno.ParecerCoordenadoriaOperacoesObservacao = viewModel.Parecer.ParecerCoordenadoriaOperacoesObservacao;
                retorno.ParecerCoordenadoriaOperacoesData = viewModel.Parecer.ParecerCoordenadoriaOperacoesData.ToString("yyyy-MM-dd");
                retorno.DocumentoUploadCoordenadoria = viewModel.Parecer.ParecerCoordenadoriaDocumentoArquivo;
                retorno.ParecerFaixaDominioId = viewModel.Parecer.ParecerFaixaDominioId;
                retorno.ParecerFaixaDominioObservacao = viewModel.Parecer.ParecerFaixaDominioObservacao;
                retorno.ParecerFaixaDominioData = viewModel.Parecer.ParecerFaixaDominioData.ToString("yyyy-MM-dd");
                retorno.DocumentoUploadFaixaDominio = viewModel.Parecer.ParecerFaixaDominioDocumentoArquivo;
                retorno.CaminhoArquivoDiretoria = viewModel.Parecer.CaminhoArquivoDiretoria;
                retorno.CaminhoArquivoRegional = viewModel.Parecer.CaminhoArquivoRegional;
                retorno.CaminhoArquivoCoordenadoria = viewModel.Parecer.CaminhoArquivoCoordenadoria;
                retorno.CaminhoArquivoFaixaDominio = viewModel.Parecer.CaminhoArquivoFaixaDominio;

                retorno.CaminhoArquivoDiretoria = (!string.IsNullOrEmpty(retorno.CaminhoArquivoDiretoria)) ? retorno.CaminhoArquivoDiretoria.Replace("C:\\der\\arquivos\\", "") : string.Empty;
                retorno.CaminhoArquivoRegional = (!string.IsNullOrEmpty(retorno.CaminhoArquivoRegional)) ? retorno.CaminhoArquivoRegional.Replace("C:\\der\\arquivos\\", "") : string.Empty;
                retorno.CaminhoArquivoCoordenadoria = (!string.IsNullOrEmpty(retorno.CaminhoArquivoCoordenadoria)) ? retorno.CaminhoArquivoCoordenadoria.Replace("C:\\der\\arquivos\\", "") : string.Empty;
                retorno.CaminhoArquivoFaixaDominio = (!string.IsNullOrEmpty(retorno.CaminhoArquivoFaixaDominio)) ? retorno.CaminhoArquivoFaixaDominio.Replace("C:\\der\\arquivos\\", "") : string.Empty;
            }

            if (viewModel.Ocupacao != null)
            {
                retorno.Assunto = viewModel.Ocupacao.Assunto;
                retorno.Observacao = viewModel.Ocupacao.Observacao;
            }

            if (viewModel.Deferimento != null)

            {
                retorno.Deferimento = new GestaoOcupacoesDeferimentoViewModel()
                {

                    Id = viewModel.Deferimento.Id,
                    DataDespachoAutorizativo = viewModel.Deferimento.DataDespachoAutorizativo != null ? viewModel.Deferimento.DataDespachoAutorizativo.Value.ToString("yyyy-MM-dd") : null,
                    NumeroProcesso = viewModel.Deferimento.NumeroProcesso,
                    DataAssinatura = viewModel.Deferimento.DataAssinatura != null ? viewModel.Deferimento.DataAssinatura.Value.ToString("yyyy-MM-dd") : null,
                    DataPublicacao = viewModel.Deferimento.DataPublicacao != null ? viewModel.Deferimento.DataPublicacao.Value.ToString("yyyy-MM-dd") : null,
                    CaminhoArquivo = (!string.IsNullOrEmpty(viewModel.Deferimento.CaminhoArquivo)) ? viewModel.Deferimento.CaminhoArquivo.Replace("C:\\der\\arquivos\\", "") : string.Empty
                };
            }
            else
            {
                retorno.Deferimento = new GestaoOcupacoesDeferimentoViewModel()
                {
                    Id = null,
                    DataDespachoAutorizativo = string.Empty,
                    NumeroProcesso = string.Empty,
                    DataAssinatura = string.Empty,
                    DataPublicacao = string.Empty,
                    CaminhoArquivo = string.Empty
                };
            }

            if (viewModel.Documentos != null && viewModel.Documentos.Count > 0)
            {
                retorno.ListaDocumentos = new List<ViewModels.GestaoOcupacoes.GestaoDocumentoViewModel>();

                foreach (var doc in viewModel.Documentos)
                {
                    retorno.ListaDocumentos.Add(new ViewModels.GestaoOcupacoes.GestaoDocumentoViewModel()
                    {
                        Id = doc.Id,
                        TipoDocumentoId = doc.TipoDocumentoId,
                        Documento = doc.Documento,
                        Arquivo = (!string.IsNullOrEmpty(doc.Arquivo)) ? doc.Arquivo.Replace(@"C:\der\arquivos\", string.Empty) : string.Empty,
                        AdicionadoPor = doc.AdicionadoPor,
                        Data = doc.DataAdicionado.Value,
                        CaminhoArquivo = doc.CaminhoArquivo
                    });
                }
            }

            if (viewModel.Ocorrencias != null && viewModel.Ocorrencias.Count > 0)
            {
                retorno.ListaOcorrencias = new List<GestaoOcupacoesOcorrenciaViewModel>();

                foreach (var oco in viewModel.Ocorrencias)
                {
                    retorno.ListaOcorrencias.Add(new GestaoOcupacoesOcorrenciaViewModel()
                    {
                        Id = oco.Id,
                        DataOcorrencia = oco.DataOcorrencia.ToString("dd/MM/yyyy"),
                        Autor = oco.Autor,
                        Area = oco.Area,
                        AreaId = oco.AreaId,
                        Ocorrencia = oco.Ocorrencia
                    });
                }
            }

            if (viewModel.Trechos != null && viewModel.Trechos.Count > 0)
            {
                retorno.ListaTrecho = new List<GestaoOcupacoesTrechoViewModel>();

                foreach (var tre in viewModel.Trechos)
                {
                    tre.Localizacao = new LocalizacaoViewModel()
                    {
                        LocalizacaoId = tre.IdLocalizacao,
                        Nome = (tre.IdLocalizacao == (int)LocalizacaoEnum.FaixaDominio) ? "faixadominio" : "nonaedificandi"
                    };

                    retorno.LadoId = tre.LadoId;

                    tre.Lado = new LadoViewModel()
                    {
                        LadoId = tre.LadoId,
                        Nome = tre.LadoNome
                    };

                    retorno.RodoviaId = tre.RodoviaId;
                    tre.Rodovia = new RodoviaTrechoViewModel()
                    {
                        RodoviaId = tre.IdRodovia,
                        Nome = tre.NomeRodovia
                    };

                    retorno.TipoOcupacaoId = (tre.IdTipoOcupacao != null) ? (int)tre.IdTipoOcupacao : 0;
                    tre.TipoOcupacao = new TipoOcupacaoViewModel
                    {
                        tipo_ocupacao_id = tre.TipoOcupacaoId,
                        nome = tre.NomeTipoOcupacao
                    };

                    retorno.TipoPassagemId = tre.TipoPassagemId;
                    tre.TipoPassagem = new TipoPassagemViewModel()
                    {
                        TipoPassagemId = tre.IdTipoPassagem,
                        Nome = tre.NomeTipoPassagem
                    };

                    retorno.TipoImplantacaoId = tre.TipoImplantacaoId;
                    tre.TipoImplantacao = new TipoImplantacaoViewModel()
                    {
                        TipoImplantacaoId = tre.IdTipoImplantacao,
                        Nome = tre.NomeTipoImplantacao
                    };
                }

                retorno.ListaTrecho.AddRange(viewModel.Trechos);
            }


            return retorno;
        }

        private List<ListaGestaoInteressadoDTO> ObtemInteressados()
        {
            try
            {
                return gestaoInteressadoBLL.ObtemListaGestaoInteressados(PerfilUsuario.UsuarioEmpresaId, PerfilUsuario.UsuarioPerfilId, PerfilUsuario.UsuarioId);
            }
            catch (Exception e)
            {
                return new List<ListaGestaoInteressadoDTO>();
            }
        }

        private List<ViewModels.ProjetosMelhorias.RodoviaViewModel> ObtemRodovia()
        {
            return rodoviaBLL.ObtemRodovia();
        }

        private List<ViewModels.DispositivoViewModel> ObtemDispositivo()
        {
            return dispositivoBLL.ObtemDispositivo();
        }

        private List<ProjetosMelhoriasRegionalViewModel> ObtemRegionais()
        {
            return regionalBLL.ObtemRegionais();
        }

        private List<ViewModels.GestaoInteressados.TipoInteressadoViewModel> ObtemTipoInteressado()
        {
            return tipoInteressadoBLL.ObtemTipoInteressado();
        }

        private List<TipoDeDocumentoViewModel> ObtemTipoDeDocumento(int? id = null)
        {
            return tipoDeDocumentoBLL.ObtemTipoDeDocumento(id);
        }

        private List<NaturezaJuridicaViewModel> ObtemNaturezaJuridica()
        {
            return naturezaJuridicaBLL.ObtemNaturezaJuridica();
        }

        private List<GestaoOcupacoesResidenciaConservacaoViewModel> ObtemResidenciaConservacoes()
        {
            return residenciaConservacoesBLL.ObtemResidenciaConservacoes();
        }

        private List<GestaoOcupacoesOrigemSolicitacaoViewModel> ObtemOrigemSolicitacoes()
        {
            return origemDaSolicitacaoBLL.ObtemOrigemSolicitacoes();
        }

        private List<GestaoOcupacoesSituacaoSolicitacaoViewModel> ObtemSituacaoSolicitacoes()
        {
            return situacaoDaSolicitacaoBLL.ObtemSituacaoSolicitacoes();
        }

        private List<GestaoOcupacoesSituacaoOcupacaoViewModel> ObtemSituacaoOcupacoes()
        {
            return situacaoDaOcupacaoBLL.ObtemSituacaoOcupacoes();
        }

        private List<AreaViewModel> ObtemAreas()
        {
            return areaBLL.ObtemAreas();
        }

        private List<GestaoOcupacoesMunicipioViewModel> ObtemMunicipio()
        {
            return municipioBLL.ObtemMunicipio();
        }

        private List<EstadoViewModel> ObtemEstado()
        {
            var retorno = new List<EstadoViewModel>();
            var unidades = unidadeBLL.ObtemUnidades();

            foreach (var unidade in unidades)
            {
                retorno.Add(new EstadoViewModel() { EstadoId = unidade.UnidadeId, Nome = unidade.Nome });
            }
            return retorno;
        }

        private List<ViewModels.ProjetosMelhorias.RodoviaViewModel> ObtemRodovias()
        {
            return rodoviaBLL.ObtemRodovia();
        }

        private List<ViewModels.DispositivoViewModel> ObtemDispositivos()
        {
            return dispositivoBLL.ObtemDispositivo();
        }

        private List<GestaoOcupacoesTipoImplantacaoViewModel> ObtemTipoImplantacoes()
        {
            return tipoDeImplantacaoBLL.ObtemTipoImplantacoes();
        }

        private List<GestaoOcupacoesTipoPassagemViewModel> ObtemTipoPassagens()
        {
            return tipoDePassagemBLL.ObtemTipoPassagens();
        }

        private List<LadoViewModel> ObtemLados()
        {
            return ladoBLL.ObtemLados();
        }

        private List<TipoDeInterferenciaViewModel> ObtemTipoDeInterferencias()
        {
            return tipoDeInterferenciaBLL.ObtemTipoDeInterferencias();
        }

        private List<TipoDeDocumentoOcupacaoViewModel> ObtemTipoDeDocumentosOcupacao()
        {
            return tipoDeDocumentoOcupacaoBLL.ObtemTipoDeDocumentosOcupacao();
        }

        private List<TipoOcupacaoViewModel> ObtemTipoOcupacoes()
        {
            return tipoOcupacoesBLL.ObtemTipoOcupacoes();
        }

        #endregion
    }
}
