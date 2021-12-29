using DER.WebApp.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class NaoAutorizadoController : HelperController
    {
        // GET: NaoAutorizado
        public ActionResult Index()
        {
            return View();
        }
    }
}