    using System.Web.Mvc;

namespace Balanca.Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Balancas");
        }

        public ActionResult Balancas()
        {
            return View();
        }
    }
}