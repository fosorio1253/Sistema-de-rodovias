using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.Common.Helper
{
    public class HelperController : Controller
    {
        protected string NomeControladora { get { return HttpContext.Request.RequestContext.RouteData.Values["controller"].ToString(); } }
        protected string NomeAcao { get { return HttpContext.Request.RequestContext.RouteData.Values["action"].ToString(); } }
        protected void obtemPermissoes(string permissao)
        {
            ViewData["Permissoes"] = new PermissoesViewModel()
            {
                Criar = User.IsInRole(permissao + Permissoes.CadastrarCodigo),
                Editar = User.IsInRole(permissao + Permissoes.EditarCodigo),
                Excluir = User.IsInRole(permissao + Permissoes.ExcluirCodigo),
                Listagem = User.IsInRole(permissao + Permissoes.ListarCodigo),
                Visualizar = User.IsInRole(permissao + Permissoes.VisualizarCodigo)
            };
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}