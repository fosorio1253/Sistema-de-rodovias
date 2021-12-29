using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Constants;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class EmailController : HelperController
    {
        private EmailBLL emailBLL;
        public EmailController()
        {
            emailBLL = new EmailBLL();
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.EmailsCodigo)]
        public ActionResult List()
        {
            obtemPermissoes(Permissoes.EmailsCodigo);
            var emails = emailBLL.GetListEmails();
            return View(emails);
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.EmailsCodigo)]
        [HttpPost]
        public JsonResult Reenviar(Emails emailSend)
        {
            obtemPermissoes(Permissoes.EmailsCodigo);
            Email email = new Email();
            var response = email.EnviarEmail(emailSend, false);
            return Json(new { status = true, message = response });
        }
        
        [AuthorizeCustomAttribute(Roles = Permissoes.EmailsCodigo)]
        [HttpPost]
        public JsonResult Enviar(Emails emailSend)
        {
            obtemPermissoes(Permissoes.EmailsCodigo);
            Email email = new Email();
            var response = email.EnviarEmail(emailSend);
            return Json(new { status = true, message = response });
        }

        [AuthorizeCustomAttribute(Roles = Permissoes.EmailsCodigo)]
        public ActionResult Editar(int id)
        {
            ViewData["SomenteVisualizar"] = false;
            return View("Edit", emailBLL.GetEmail(id));
        }

        [HttpPost]
        public JsonResult Update(Emails email)
        {
            var eml = emailBLL.GetEmail(email.Id);
            eml.CorpoEmail = email.CorpoEmail;
            eml.Destinatario = email.Destinatario;
            var resposta = emailBLL.UpdateEmail(eml);
            return Json(new { status = resposta, message = resposta ? "Alterado com sucesso" : "Não foi possível alterar" });
        }
    }
}