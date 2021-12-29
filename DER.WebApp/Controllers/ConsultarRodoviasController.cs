using AutoMapper;
using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Business;
using DER.WebApp.ViewModels.ConsultarRodovias;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class ConsultarRodoviasController : HelperController
    {
        private ConsultarRodoviasBLL consultarRodoviasBLL;
        private RodoviaBLL rodoviaBLL;

        public ConsultarRodoviasController()
        {
            consultarRodoviasBLL = new ConsultarRodoviasBLL();
            rodoviaBLL = new RodoviaBLL();
        }

        public ActionResult Index()
        {
            return View(RetornaViewModelNovo());
        }

        private ConsultarRodoviasViewModelsParams RetornaViewModelNovo()
        {
            var retorno = new ConsultarRodoviasViewModelsParams();
                        
            retorno.Rodovias = new SelectList(ObtemRodovia(), "rod_id", "rod_codigo");
            return retorno;
        }

        private List<RodoviaViewModel> ObtemRodovia()
        {
            return rodoviaBLL.ObterRodovias();
        }

        [HttpPost]
        public ActionResult Buscar(ConsultarRodoviasViewModelsParams logViewModel)
        {
            try
            {
                return Json(new { data = consultarRodoviasBLL.ObtemLista(logViewModel) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new System.Exception("Ocorreu um erro. Entre em contato com o suporte.");
            }
        }
    }
}