using DER.WebApp.Domain.Business;
using DER.WebApp.ViewModels.API;
using System;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class APIController : Controller
    {
        DadosMestresBLL dadosMestresBLL;
        public APIController()
        {
            dadosMestresBLL = new DadosMestresBLL();
        }
        public ActionResult Index()
        {
            return View(new APIViewModel().RetornaApisSirgeo());
        }

        public ActionResult ExecutarServico(int id)
        {
            try
            {
                var viewModel = new APIViewModel();
                var healthCheck = viewModel.HealtCheckAPI(id);
                return Json(healthCheck);
            }
            catch(Exception ex)
            {
                var healthCheck = new RetornoHealtCheckAPI()
                {
                    Sucesso = false,
                    Mensagem = ex.Message
                };

                return Json(healthCheck);
            }
        }
    }
}