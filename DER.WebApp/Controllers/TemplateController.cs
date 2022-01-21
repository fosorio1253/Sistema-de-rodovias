using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Constants;
using DER.WebApp.Helper;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class TemplateController : HelperController
    {
        private TemplateBLL templateBLL;
        private Logger logger;

        public TemplateController()
        {
            templateBLL = new TemplateBLL();
            logger = new Logger("Template");
        }

        public ActionResult Novo()
        {
            return View();
        }

        //[AuthorizeCustomAttribute(Roles = Permissoes.EmailsCodigo)]
        [HttpPost]
        public JsonResult Criar(Template template)
        {
            obtemPermissoes(Permissoes.EmailsCodigo);
            var response = templateBLL.SaveTemplate(template);
            logger.salvarLog(TipoAlteracao.Criacao, response.ToString(), template);
            return Json(new { status = response, message = response });
        }

        //[AuthorizeCustomAttribute(Roles = Permissoes.TemplatesCodigo)]
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.TemplatesCodigo);
            var templates = templateBLL.GetListTemplates();
            return View(templates);
        }

        [HttpGet]
        public JsonResult Templates()
        {
            return Json(templateBLL.GetListTemplates(), JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeCustomAttribute(Roles = Permissoes.TemplatesCodigo)]
        public ActionResult Editar(int id)
        {
            ViewData["SomenteVisualizar"] = false;
            var templates = templateBLL.GetListTemplates();
            foreach (var temp
                in templates)
            {
                if (temp.Id == id)
                {
                    return View("Edit", temp);
                }
            }
            return View(templates);
        }

        [HttpPost]
        public JsonResult Update(Template template)
        {
            var resposta = templateBLL.UpdateTemplate(template);
            logger.salvarLog(TipoAlteracao.Exclusao, template.Id.ToString(),template);
            return Json(new { status = resposta, message = resposta ? "Alterado com sucesso" : "Não foi possível alterar" });
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            logger.salvarLog(TipoAlteracao.Exclusao, id.ToString());
            var resposta = templateBLL.DeleteTemplate(id);
            return Json(new { status = resposta, message = resposta ? "Excluido com sucesso" : "Não foi possível excluir" });
        }

    }
}