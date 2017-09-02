    using System.Web.Mvc;

namespace Balanca.Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View("~/Views/Home/Sobre.cshtml");
        }

        public ActionResult Contato()
        {
            return View("~/Views/Home/Contato.cshtml");
        }

    }
}