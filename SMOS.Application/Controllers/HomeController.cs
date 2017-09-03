    using System.Web.Mvc;

namespace SMOS.Application.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        //http://benfoster.io/blog/aspnet-identity-stripped-bare-mvc-part-1
        [AllowAnonymous]
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