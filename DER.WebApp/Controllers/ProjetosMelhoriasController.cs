using AutoMapper;
using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Helper;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using DER.WebApp.ViewModels.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    [AuthorizeCustomAttribute(Roles = Permissoes.ProjetosMelhoriasCodigo)]
    public class ProjetosMelhoriasController : HelperController
    {
        #region Construtor

        private ProjetosMelhoriasBLL projetosMelhoriasBLL;       
        private MunicipioBLL municipioBLL;
        private RodoviaBLL rodoviaBLL;
        private DispositivoBLL dispositivoBLL;
        private RegionalProjetosMelhoriasBLL regionalBLL;
        private LadoBLL ladoBLL;
        private Logger logger;

        public ProjetosMelhoriasController()
        {          
            projetosMelhoriasBLL = new ProjetosMelhoriasBLL();
            municipioBLL = new MunicipioBLL();
            rodoviaBLL = new RodoviaBLL();
            regionalBLL = new RegionalProjetosMelhoriasBLL();
            ladoBLL = new LadoBLL();
            logger = new Logger("Projeto Melhorias");
        }

        #endregion

        #region Metodos Publicos

        [AuthorizeCustom(Roles = Permissoes.ProjetosMelhoriasCodigo)]
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.ProjetosMelhoriasCodigo);
            var projetosMelhorias = projetosMelhoriasBLL.ObtemListaProjetosMelhorias();
            return View(projetosMelhorias);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.ProjetosMelhoriasCodigo + Permissoes.CadastrarCodigo)]
        //[AuthorizeCustomAttribute(Roles = Permissoes.CadastrarCodigo)]

        public ActionResult Novo()
        {
            return View(this.RetornaViewModelNovo());
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.ProjetosMelhoriasCodigo + Permissoes.EditarCodigo)]
        public ActionResult Editar(int id)
        {
            return View("Novo", this.RetornaViewModelNovo(id));
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.ProjetosMelhoriasCodigo + Permissoes.VisualizarCodigo)]
        public ActionResult Visualizar(int id)
        {
            return View("Novo", this.RetornaViewModelNovo(id));
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.ProjetosMelhoriasCodigo + Permissoes.ExcluirCodigo)]
        public ActionResult Excluir(int id)
        {
            try
            {
                var ant = projetosMelhoriasBLL.ObtemId(id);
                projetosMelhoriasBLL.Excluir(id);
                logger.salvarLog(TipoAlteracao.Exclusao, id.ToString(), null, ant);
                return Json(new { status = true });                
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return Json(new { status = false });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(ProjetosMelhoriasViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(viewModel.Id != 0)
                    {
                        logger.salvarLog(TipoAlteracao.Edicao, viewModel.Id.ToString(), viewModel, projetosMelhoriasBLL.ObtemId(viewModel.Id));
                    }else
                    {
                        logger.salvarLog(TipoAlteracao.Criacao, viewModel.Id.ToString(),viewModel);
                    }
                    var valid = projetosMelhoriasBLL.Inserir(viewModel);

                    return Json(valid);
                }

                return Json(new { valid = false });
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        #endregion

        #region Metodos Privados

        private ProjetosMelhoriasViewModel RetornaViewModelNovo(int? id = null)
        {
            var retorno = new ProjetosMelhoriasViewModel();

            if (id != null)
            {
                retorno = ObtemProjetosMelhorias((int)id);
            }

            retorno.Info = new ProjetosMelhoriasInformacoesRelevantesViewModel();
            retorno.Municipios = new SelectList(ObtemMunicipio(), "municipio_id", "municipio");
            retorno.Regionais = new SelectList(ObtemRegionais(), "RegionalId", "Nome");
            retorno.Rodovias = new SelectList(ObtemRodovia(), "RodoviaId", "Nome");
            retorno.Lados = new SelectList(ObtemLados(), "LadoId", "Nome");
            ViewBag.Usuario = User.Identity.Name.ToString();
            ViewBag.DataAtual = DateTime.Now;
            ViewBag.DataAtualizacao = DateTime.Now; //Aqui deve ser passado a data de atualzacao do objeto
            ViewData["PermissaoAprovacao"] = User.IsInRole(Permissoes.ProjetosMelhoriasCodigo + Permissoes.AprovarCodigo);
            return retorno;
        }

        [HttpPost]

        private ProjetosMelhoriasViewModel ObtemProjetosMelhorias(int id)
        {
            return projetosMelhoriasBLL.ObtemInfoId(id);
        }

        private List<MunicipioViewModel> ObtemMunicipio()
        {
            return municipioBLL.ObtemMunicipio();
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

        private List<LadoViewModel> ObtemLados()
        {
            return ladoBLL.ObtemLados();
        }

        #endregion
    }
}