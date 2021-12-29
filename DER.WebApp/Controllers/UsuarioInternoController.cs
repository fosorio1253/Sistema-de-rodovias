using AutoMapper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.Validadores;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioInternoCodigo)]
    public class UsuarioInternoController : HelperController
    {
        private UsuarioBLL usuarioBLL;
        private GrupoBLL grupoBLL;
        private RegionalBLL regionalBLL;

        public UsuarioInternoController()
        {
            usuarioBLL = new UsuarioBLL();
            grupoBLL = new GrupoBLL();
            regionalBLL = new RegionalBLL();
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioInternoCodigo)]
        // GET: Usuario
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.UsuarioInternoCodigo);
            var Usuarios = usuarioBLL.ObtemTodos(false).ToList();
            return View(Usuarios);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioInternoCodigo + Permissoes.CadastrarCodigo)]
        // GET: Usuario
        public ActionResult Novo()
        {
            ObtemGrupo();
            var usuario = Mapper.Map<Usuario, UsuarioInternoViewModel>(new Usuario());
            usuario.Regionais = new SelectList(ObtemRegionais(), "RegionalId", "Nome");

            ViewData["SomenteVisualizar"] = false;
            ViewData["DesabilitarRegionalId"] = false;
            return View(usuario);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioInternoCodigo + Permissoes.EditarCodigo)]
        // GET: Usuario
        public ActionResult Editar(int Id)
        {
            ObtemGrupo();
            var usuario = Mapper.Map<Usuario, UsuarioInternoViewModel>(ObtemUsuario(Id));

            ViewData["SomenteVisualizar"] = true;
            ViewData["DesabilitarRegionalId"] = false;
            usuario.Regionais = new SelectList(ObtemRegionais(), "RegionalId", "Nome");
            return View("Novo", usuario);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.UsuarioInternoCodigo + Permissoes.VisualizarCodigo)]
        public ActionResult Visualizar(int Id)
        {
            ObtemGrupo();
            var usuario = Mapper.Map<Usuario, UsuarioInternoViewModel>(ObtemUsuario(Id));
            usuario.Regionais = new SelectList(ObtemRegionais(), "RegionalId", "Nome");

            ViewData["SomenteVisualizar"] = true;
            ViewData["DesabilitarRegionalId"] = true;
            return View("Novo", usuario);
        }
        
        [HttpPost]
        public ActionResult Salvar(UsuarioInternoViewModel Usuario)
         {
             if(ModelState.IsValid)
            {
                if (!CPF.Validar(Usuario.CPF))
                {
                    return Json(new UsuarioValidatorViewModel { validCPF = false, valid = false });
                }

                var usuario = Mapper.Map<UsuarioInternoViewModel, Usuario>(Usuario);
                var valid = usuarioBLL.Salvar(usuario);
                valid.validCPF = true;
                return Json(valid);
            }
            return Json(new UsuarioValidatorViewModel() { valid = false , validCPF = true} );
        }

        [HttpPost]
        [AuthorizeCustom(Roles = Permissoes.UsuarioInternoCodigo + Permissoes.AprovarCodigo)]
        public ActionResult Aprovar(bool aprovar, int idUsuario, string justificativa = "")
        {
            var aprovacao = aprovar ? (int)StatusAprovacaoEnum.Aprovado : (int)StatusAprovacaoEnum.Reprovado;
            var valid = usuarioBLL.AprovacaoUsuario(idUsuario, aprovacao);

            return Json(new { status = valid });
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var valid = usuarioBLL.Excluir(id);
            return Json(new { status = valid });
        }

        private void ObtemGrupo()
        {
            ViewData["Grupos"] = grupoBLL.ObtemTodos().Select(x => new { Text = x.Nome, Value = x.Id });
            ViewData["PermissaoAprovacao"] = User.IsInRole(Permissoes.UsuarioInternoCodigo + Permissoes.AprovarCodigo);
        }

        private Usuario ObtemUsuario(int id)
        {
            var usuario = usuarioBLL.ObtemId(id);
            usuario.GruposIDs = new List<int>();
            usuario.Grupos.ForEach(x => usuario.GruposIDs.Add(x.Id));
            return usuario;
        }

        private List<RegionalViewModel> ObtemRegionais()
        {
            return regionalBLL.ObtemRegionais();
        }
    }
}