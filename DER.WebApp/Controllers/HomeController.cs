using DER.WebApp.Common.Helper;
using System.Web.Mvc;

namespace DER.WebApp.Controllers
{
    public class HomeController : HelperController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}