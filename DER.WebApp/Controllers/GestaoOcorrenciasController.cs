using AutoMapper;
using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using DER.WebApp.ViewModels.GestaoOcorrencias;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using DER.WebApp.ViewModels.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using DER.WebApp.ViewModels.GestaoInteressados;

namespace DER.WebApp.Controllers
{
    [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcorrenciasCodigo)]
    public class GestaoOcorrenciasController : HelperController
    {
        #region Construtor

        private GestaoOcorrenciaBLL gestaoOcorrenciaBLL;
        private ProjetosMelhoriasBLL projetosMelhoriasBLL;
        private GestaoOcupacaoBLL gestaoOcupacaoBLL;
        private RodoviaBLL rodoviaBLL;
        private DispositivoBLL dispositivoBLL;
        private RegionalProjetosMelhoriasBLL regionalBLL;
        private LadoBLL ladoBLL;
        private TipoOcupacoesBLL tipoOcupacoesBLL;
        private ResidenciaConservacoesBLL residenciaConservacoesBLL;
        private AssuntoBLL assuntoBLL;
        private SeveridadeBLL severidadeBLL;
        private StatusBLL statusBLL;
        private TrechosBLL trechosBLL;
        private MunicipioGestaoOcupacaoBLL municipioBLL;
        private TipoInteressadoBLL tipoInteressadoBLL;
        private NaturezaJuridicaBLL naturezaJuridicaBLL;
        private UnidadeGestaoOcupacaoBLL unidadeBLL;

        public GestaoOcorrenciasController()
        {
            gestaoOcorrenciaBLL = new GestaoOcorrenciaBLL();
            projetosMelhoriasBLL = new ProjetosMelhoriasBLL();
            gestaoOcupacaoBLL = new GestaoOcupacaoBLL();
            rodoviaBLL = new RodoviaBLL();
            regionalBLL = new RegionalProjetosMelhoriasBLL();
            ladoBLL = new LadoBLL();
            tipoOcupacoesBLL = new TipoOcupacoesBLL();
            residenciaConservacoesBLL = new ResidenciaConservacoesBLL();
            assuntoBLL = new AssuntoBLL();
            severidadeBLL = new SeveridadeBLL();
            statusBLL = new StatusBLL();
            trechosBLL = new TrechosBLL();
            municipioBLL = new MunicipioGestaoOcupacaoBLL();
            tipoInteressadoBLL = new TipoInteressadoBLL();
            naturezaJuridicaBLL = new NaturezaJuridicaBLL();
            unidadeBLL = new UnidadeGestaoOcupacaoBLL();

        }

        #endregion

        #region Metodos Publicos

        [AuthorizeCustom(Roles = Permissoes.GestaoOcorrenciasCodigo)]
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.GestaoOcorrenciasCodigo);
            ViewBag.Usuario = User.Identity.Name.ToString();
            int UsuarioPerfilId = PerfilUsuario.UsuarioPerfilId;
            if (UsuarioPerfilId == 23)
            {
                ViewBag.Usuario = "admin";
            }
            var gestaoOcorrencias = gestaoOcorrenciaBLL.ObtemListaGestaoOcorrencia(ViewBag.Usuario);
            return View(gestaoOcorrencias);
            //return View();
        }
        
        [AuthorizeCustom(Roles = Permissoes.GestaoOcorrenciasCodigo)]
        public JsonResult ListOcorrencias()
        {
            obtemPermissoes(Permissoes.GestaoOcorrenciasCodigo);
            List<GestaoOcorrenciasViewModel> listaRetorno = new List<GestaoOcorrenciasViewModel>();
            ViewBag.Usuario = User.Identity.Name.ToString();

            int UsuarioPerfilId = PerfilUsuario.UsuarioPerfilId;
            if (UsuarioPerfilId == 23)
            {
                ViewBag.Usuario = "admin";
            }
            var gestaoOcorrencias = gestaoOcorrenciaBLL.ObtemTodasOcorrencias(ViewBag.Usuario);
            foreach (var item in gestaoOcorrencias)
            {
                item.Observacoes = gestaoOcorrenciaBLL.ObtemInfoId(item.Id).Observacoes;
            }
            return Json(gestaoOcorrencias, JsonRequestBehavior.AllowGet);
            //return View();
        }

        [AuthorizeCustom(Roles = Permissoes.GestaoOcorrenciasCodigo)]
        [HttpPost]
        public JsonResult SaveOcorrencias(GestaoOcorrenciasViewModelApi model)
        {
            obtemPermissoes(Permissoes.GestaoOcorrenciasCodigo);
            var gestaoOcorrencias = gestaoOcorrenciaBLL.InserirApi(model);
            return Json(new { Status = gestaoOcorrencias.valid, Message = gestaoOcorrencias.mensagem });
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcorrenciasCodigo + Permissoes.CadastrarCodigo)]
        public ActionResult Novo()
        {
            ViewData["SomenteVisualizar"] = false;
            return View(this.RetornaViewModelNovo());
            //return View();
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcorrenciasCodigo + Permissoes.EditarCodigo)]
        public ActionResult Editar(int id)
        {
            ViewData["SomenteVisualizar"] = false;
            return View("Novo", this.RetornaViewModelNovo(id));
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcorrenciasCodigo + Permissoes.VisualizarCodigo)]
        public ActionResult Visualizar(int id)
        {
            ViewData["SomenteVisualizar"] = true;
            return View("Novo", this.RetornaViewModelNovo(id));
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GestaoOcorrenciasCodigo + Permissoes.ExcluirCodigo)]
        public ActionResult Excluir(int id)
        {
            try
            {
                gestaoOcorrenciaBLL.Excluir(id);
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return Json(new { status = false });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(GestaoOcorrenciasViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var valid = gestaoOcorrenciaBLL.Inserir(viewModel);

                    return Json(valid);
                }

                return Json(new { valid = false });
            }
            catch (Exception)
            {
                throw;
            }
        }
        public JsonResult ConsultarInteressado(InteressadoOcupacaoParansDTO viewModel)
        {
            ViewBag.Usuario = User.Identity.Name.ToString();
            return Json(gestaoOcupacaoBLL.GetInteressadoByParams(viewModel, ViewBag.Usuario));
        }

        public FileResult DownloadArquivo(string caminhoArquivo)
        {
            var extensao = (caminhoArquivo.Contains(".pdf")) ? ".pdf" : ".jpg";
            string contentType = (caminhoArquivo.Contains(".pdf")) ? "application/pdf" : "image/jpg";
            string nomeArquivo = DateTime.Now.ToString("yyyyMMddHHmmss") + extensao;
            return File(caminhoArquivo, contentType, nomeArquivo);
        }

        public JsonResult SalvarArquivo(GestaoOcorrenciaDocumentoViewModel viewModel)
        {
            gestaoOcorrenciaBLL.SalvarArquivo(viewModel);
            return null;
        }

        #endregion

        #region Metodos Privados

        private GestaoOcorrenciasViewModel RetornaViewModelNovo(int? id = null)
        {
            var retorno = new GestaoOcorrenciasViewModel();

            if (id != null)
            {
                retorno = ObtemGestaoOcorrencias((int)id);
            }

            //retorno.Info = new ProjetosMelhoriasInformacoesRelevantesViewModel();
            retorno.Regionais = new SelectList(ObtemRegionais(), "RegionalId", "Nome");
            retorno.ResidenciaConservacoes = new SelectList(ObtemResidenciaConservacoes(), "ResidenciaConservacaoId", "Nome");
            retorno.Trechos = new SelectList(ObtemTrechos(), "TrechoId", "Nome");
            retorno.TipoOcupacoes = new SelectList(ObtemTipoOcupacoes(), "TipoOcupacaoId", "Nome");
            retorno.Rodovias = new SelectList(ObtemRodovia(), "RodoviaId", "Nome");
            retorno.Lados = new SelectList(ObtemLados(), "LadoId", "Nome");
            retorno.Assuntos = new SelectList(ObtemAssuntos(), "AssuntoId", "Nome");
            retorno.Severidades = new SelectList(ObtemSeveridades(), "SeveridadeId", "Nome");
            retorno.Status = new SelectList(ObtemStatus(), "StatusId", "Nome");
            retorno.Municipios = new SelectList(ObtemMunicipio(), "MunicipioId", "Nome");
            retorno.Estados = new SelectList(ObtemEstado(), "EstadoId", "Nome");
            retorno.TiposInteressados = new SelectList(ObtemTipoInteressado(), "TipoInteressadoId", "Nome");
            retorno.NaturezasJuridicas = new SelectList(ObtemNaturezaJuridica(), "NaturezaJuridicaId", "Nome");
            ViewBag.Usuario = User.Identity.Name.ToString();
            ViewBag.DataAtual = DateTime.Now;
            ViewBag.DataAtualizacao = DateTime.Now; //Aqui deve ser passado a data de atualzacao do objeto
            ViewData["PermissaoAprovacao"] = User.IsInRole(Permissoes.GestaoOcorrenciasCodigo + Permissoes.AprovarCodigo);
            return retorno;
        }

        [HttpPost]

        private GestaoOcorrenciasViewModel ObtemGestaoOcorrencias(int id)
        {
            return gestaoOcorrenciaBLL.ObtemInfoId(id);
        }

        private List<ProjetosMelhoriasRegionalViewModel> ObtemRegionais()
        {
            return regionalBLL.ObtemRegionais();
        }
        private List<GestaoOcupacoesResidenciaConservacaoViewModel> ObtemResidenciaConservacoes()
        {
            return residenciaConservacoesBLL.ObtemResidenciaConservacoes();
        }
        private List<TrechoViewModel> ObtemTrechos()
        {
            return trechosBLL.ObtemTrechos();
        }

        private List<TipoOcupacaoViewModel> ObtemTipoOcupacoes()
        {
            return tipoOcupacoesBLL.ObtemTipoOcupacoes();
        }

        private List<ViewModels.ProjetosMelhorias.RodoviaViewModel> ObtemRodovia()
        {
            return rodoviaBLL.ObtemRodovia();
        }

        private List<ViewModels.ProjetosMelhorias.DispositivoViewModel> ObtemDispositivo()
        {
            return dispositivoBLL.ObtemDispositivo();
        }

        private List<LadoViewModel> ObtemLados()
        {
            return ladoBLL.ObtemLados();
        }

        private List<AssuntosViewModel> ObtemAssuntos()
        {
            return assuntoBLL.ObtemAssuntos();
        }

        private List<SeveridadesViewModel> ObtemSeveridades()
        {
            return severidadeBLL.ObtemSeveridades();
        }

        private List<StatusOcorrenciaViewModel> ObtemStatus()
        {
            return statusBLL.ObtemStatus();
        }

        private List<GestaoOcupacoesMunicipioViewModel> ObtemMunicipio()
        {
            return municipioBLL.ObtemMunicipio();
        }

        private List<NaturezaJuridicaViewModel> ObtemNaturezaJuridica()
        {
            return naturezaJuridicaBLL.ObtemNaturezaJuridica();
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
        private List<ViewModels.GestaoInteressados.TipoInteressadoViewModel> ObtemTipoInteressado()
        {
            return tipoInteressadoBLL.ObtemTipoInteressado();
        }

        #endregion
    }
}