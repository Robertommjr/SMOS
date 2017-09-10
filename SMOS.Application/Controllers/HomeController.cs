using System.Web.Mvc;

namespace SMOS.Application.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //http://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-1

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