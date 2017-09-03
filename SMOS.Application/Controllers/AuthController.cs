using System.Web.Mvc;

namespace Balanca.Application.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult LogIn()
        {
            return View("~/Views/Auth/LogIn.cshtml");
        }
    }
}