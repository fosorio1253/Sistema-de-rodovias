using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.ViewModels;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class DadosMestresController : HelperController
    {
        DadosMestresBLL dadosMestresBLL;
        public DadosMestresController()
        {
            dadosMestresBLL = new DadosMestresBLL();
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.DadosMestresCodigo)]
        // GET: DadosMaster
        public ActionResult List()
        {
            var tabelas = dadosMestresBLL.obtemTodasTabelas();
            return View(tabelas);
        }

        // GET: Usuario
        public ActionResult Editar(string id)
        {
            obtemPermissoes(Permissoes.DadosMestresCodigo + id);
            var tabela = dadosMestresBLL.obtemTabela(id);
            return View("novo", tabela);
        }

        public ActionResult Visualizar(string id)
        {
            obtemPermissoes(Permissoes.DadosMestresCodigo + id);
            var tabela = dadosMestresBLL.obtemTabela(id);
            return View("novo", tabela);
        }

        public ActionResult Salvar(DadosMestresRetornoViewModel dadosMestres)
        {
            var valid = dadosMestresBLL.Salvar(dadosMestres);
            return Json(new { status = valid });
        }

        public ActionResult Excluir(string tabelaId, int id)
        {
            var valid = dadosMestresBLL.Excluir(tabelaId, id);
            return Json(new { status = valid });
        }
    }
}