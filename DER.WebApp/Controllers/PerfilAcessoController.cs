using AutoMapper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DER.WebApp.Helper;

namespace WebApp.Controllers
{
    [AuthorizeCustomAttribute(Roles = Permissoes.PerfilCodigo)]
    public class PerfilAcessoController : HelperController
    {
        private PermissaoBLL permissaoBLL;
        private PerfilBLL perfilBLL;
        private Logger logger;
        public PerfilAcessoController()
        {
            permissaoBLL = new PermissaoBLL();
            perfilBLL = new PerfilBLL();
            logger = new Logger("Perfil Acesso");
        }
        // GET: UsuarioExterno

        [AuthorizeCustomAttribute(Roles = Permissoes.PerfilCodigo)]
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.PerfilCodigo);
            var perfil = perfilBLL.ObtemTodos();
            return View(perfil);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.PerfilCodigo + Permissoes.CadastrarCodigo)]
        public ActionResult Novo()
        {
            ObtemListaPermissoes();
            var perfil = new PerfilAcessoViewModel();
            perfil.PermissoesIds = new List<int>();
            return View(perfil);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.PerfilCodigo + Permissoes.EditarCodigo)]
        public ActionResult Editar(int id)
        {
            ObtemListaPermissoes();
            var perfil = perfilBLL.ObtemId(id);
            return View("Novo", perfil);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.PerfilCodigo + Permissoes.VisualizarCodigo)]
        public ActionResult Visualizar(int id)
        {
            ObtemListaPermissoes();
            var perfil = perfilBLL.ObtemId(id);
            return View("Novo", perfil);
        }

        [HttpPost]
        public ActionResult Salvar(PerfilAcessoViewModel Perfil)
        {
            if (ModelState.IsValid)
            {
                var exists = perfilBLL.ExisteNomeCadastro(Perfil.Nome, Perfil.Id);

                if (exists)
                {
                    return Json(new { exists = exists });
                }

                if (Perfil.Id != 0)
                {
                    var perf = perfilBLL.ObtemId(Perfil.Id);
                    logger.salvarLog(TipoAlteracao.Edicao, Perfil.Id.ToString(), Perfil, perf);
                }
                else
                {
                    logger.salvarLog(TipoAlteracao.Criacao, Perfil.Id.ToString(), Perfil);
                }

                var valid = perfilBLL.Salvar(Perfil);

                return Json(new { status = valid != 0 ? true : false });
            }
            return Json(new { status = false, html = View("novo", Perfil) });
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            
            var valid = perfilBLL.Excluir(id);
            if (valid)
            {
                logger.salvarLog(TipoAlteracao.Exclusao, id.ToString(), null, perfilBLL.ObtemId(id));
            }
            return Json(new { status = valid });
        }

        private void ObtemListaPermissoes()
        {
            ViewData["Permissoes"] = permissaoBLL.ObtemListaPermissoes();
        }
    }
}