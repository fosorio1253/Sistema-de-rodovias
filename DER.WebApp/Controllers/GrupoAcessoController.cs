using AutoMapper;
using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.Helper;
using DER.WebApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    [AuthorizeCustomAttribute(Roles = Permissoes.GrupoCodigo)]
    public class GrupoAcessoController : HelperController
    {
        private PerfilBLL _perfilBLL;
        private UsuarioBLL _usuarioBLL;
        private GrupoBLL _grupoBLL;
        private Logger logger;

        public GrupoAcessoController()
        {
            _perfilBLL = new PerfilBLL();
            _usuarioBLL = new UsuarioBLL();
            _grupoBLL = new GrupoBLL();
            logger = new Logger("Grupo Acesso");
        }
        [AuthorizeCustomAttribute(Roles = Permissoes.GrupoCodigo)]
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.GrupoCodigo);
            var grupos = _grupoBLL.ObtemTodos();
            return View(grupos);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GrupoCodigo + Permissoes.CadastrarCodigo)]
        public ActionResult Novo()
        {
            ObtemSelects();
            var grupo = new Grupo();
            grupo.Usuarios = _usuarioBLL.ObtemTodos();
            return View(Mapper.Map<Grupo,GrupoViewModel>(grupo));
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GrupoCodigo + Permissoes.EditarCodigo)]
        public ActionResult Editar(int Id)
        {
            ObtemSelects();
            var grupo = _grupoBLL.ObtemId(Id);
            grupo.Usuarios = _usuarioBLL.ObtemTodos();
            return View("Novo", grupo);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.GrupoCodigo + Permissoes.VisualizarCodigo)]
        public ActionResult Visualizar(int Id)
        {
            ObtemSelects();
            var grupo = _grupoBLL.ObtemId(Id);
            grupo.Usuarios = _usuarioBLL.ObtemTodos();
            return View("Novo", grupo);
        }

        public ActionResult Salvar(GrupoViewModel Grupo)
        {
            if (ModelState.IsValid)
            {
                var exists = _grupoBLL.ExisteNomeCadastro(Grupo.Nome, Grupo.Id);

                if (exists)
                {
                    return Json(new { exists = exists });
                }

                var valid = _grupoBLL.Salvar(Grupo);
                if (valid != 0)
                {
                    logger.salvarLog(TipoAlteracao.Criacao, valid.ToString(), _grupoBLL.ObtemId(valid));
                }
                return Json(new { status = valid == 0 ? false : true });
            }
            return Json(new { status = false });
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            logger.salvarLog(TipoAlteracao.Exclusao, id.ToString(), null, _grupoBLL.ObtemId(id));
            var valid = _grupoBLL.Excluir(id);
            return Json(new { status = valid });
        }



        private void ObtemSelects()
        {
            ViewData["Perfis"] = _perfilBLL.ObtemTodos().Select(x => new { Text = x.Nome, Value = x.Id } );
        }
    }
}