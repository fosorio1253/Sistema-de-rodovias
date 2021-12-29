using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : HelperController
    {

        private EmpresaBLL empresaBLL;
        private UsuarioBLL usuarioBLL;
        private PerfilBLL perfilBLL;
        private GestaoInteressadoBLL gestaoInteressadoBLL;


        public LoginController()
        {
            empresaBLL = new EmpresaBLL();
            usuarioBLL = new UsuarioBLL();
            perfilBLL = new PerfilBLL();
            gestaoInteressadoBLL = new GestaoInteressadoBLL();

        }

        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult ValidarUsuario(UsuarioViewModel paramUsuario)
        {
            PerfilUsuario.LoginUsuario = paramUsuario.usu_login;
            paramUsuario = new LoginBLL().ValidarLogin(paramUsuario);
            bool valid = paramUsuario == null ? false : true;

            if (valid)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, paramUsuario.usu_nome),
                    new Claim(ClaimTypes.Email, paramUsuario.usu_login),
                    new Claim(ClaimTypes.NameIdentifier, paramUsuario.usu_id.ToString())
                },
                "ApplicationCookie");
                var listClaims = new List<Claim>();
                paramUsuario.Permissoes.ForEach(x => listClaims.Add(new Claim(ClaimTypes.Role, x)));
                identity.AddClaims(listClaims);

                Session["userId"] = paramUsuario.usu_id;

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);
                var UsuarioId = paramUsuario.usu_id;
                PerfilUsuario.PerfildoUsuario = perfilBLL.ObtemPerfilUsuario(UsuarioId).PerfilUsuario;
                PerfilUsuario.UsuarioEmpresaId = perfilBLL.ObtemPerfilUsuario(UsuarioId).UsuarioEmpresaId;
                PerfilUsuario.UsuarioPerfilId = perfilBLL.ObtemPerfilUsuario(UsuarioId).UsuarioPerfilId;
                PerfilUsuario.DataCredenciamento = perfilBLL.ConsultarValidadeCredenciamentoLogin(UsuarioId);
                PerfilUsuario.UsuarioId = paramUsuario.usu_id;


            }

            return Json(new { status = valid, usuario = paramUsuario, JsonRequestBehavior.AllowGet });
        }

        public ActionResult NovoUsuario(string token)
        {
            var usuario = new UsuarioExternoViewModel();
            if (!String.IsNullOrEmpty(token))
            {
                usuario = usuarioBLL.ObtemPeloToken(token);
                if (usuario == null)
                {
                    usuario = new UsuarioExternoViewModel();
                }

            }
            ViewData["Empresas"] = empresaBLL.ObtemTodos().Select(x => new { Text = x.Nome, Value = x.Id });
            return View(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarUsuario(UsuarioExternoViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(usuario.CNPJEmpresa))
                {
                    var exists = empresaBLL.VerificaCNPJExiste(usuario.CNPJEmpresa);

                    if (exists)
                    {
                        return Json(new UsuarioValidatorViewModel() { validCNPJ = true, validCPF = true, valid = false, CNPJExists = true });
                    }

                    if (!CNPJ.Validar(usuario.CNPJEmpresa))
                    {
                        return Json(new UsuarioValidatorViewModel { validCNPJ = false, validCPF = false, valid = false });
                    }
                }

                if (!CPF.Validar(usuario.CPF))
                {
                    return Json(new UsuarioValidatorViewModel { validCPF = false, validCNPJ = true, valid = false });
                }

                var valid = usuarioBLL.SalvarComEmpresa(usuario);
                valid.validCNPJ = true;
                valid.validCPF = true;
                return Json(valid);
            }
            return Json(new UsuarioValidatorViewModel() { valid = false, validCNPJ = true, validCPF = true });
        }

        [HttpPost]
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return Json(new { Mensagem = "Favor faça o login novamente!", status = true, JsonRequestBehavior.AllowGet });
        }

        public ActionResult EsqueciMinhaSenha(string email)
        {

            var valid = usuarioBLL.EnviaUsuarioSenhaEmail(email);

            if (valid)
            {
                usuarioBLL.SolicitaNovaSenhaUsuario(email,2);

                return Json(new { status = true, mensagem = "" });
            }

            return Json(new { status = false, mensagem = "Usuario não encontrado" });
        }

        [HttpGet]
        public ActionResult AlteraSenha(string token)
        {
            var tokenValido = usuarioBLL.VerificaToken(token);
            return View("AlteraSenha", "", tokenValido ? token : "");
        }

        public ActionResult AlterarSenhaUsuario(int idUsuario, string SenhaAtual, string SenhaNova)
        {
            var valid = usuarioBLL.AlterarSenha(idUsuario, SenhaAtual, SenhaNova);

            return Json(new { status = valid });
        }

        [HttpPost]
        public ActionResult AlterarSenha(AlteraSenhaViewModel alterarSenha)
        {
            var retorno = usuarioBLL.AlterarSenhaComValidacao(alterarSenha);

            return Json(retorno);

        }
    }
}