using Balanca.Application.ViewModel;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult LogIn(string modelJson, bool agreement) {

            
            var serializer = new JavaScriptSerializer();
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var model = JsonConvert.DeserializeObject<LogInViewModel>(modelJson);


            if (!ModelState.IsValid)
            {
                return View();
            }

            // Don't do this in production!
            if (model.Email == "admin@admin.com" && model.Password == "password")
            {
                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, "Fábio"),
                new Claim(ClaimTypes.Email, "fabio.carvalllho@gmail.com"),
                new Claim(ClaimTypes.Country, "England")
            },
                    "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}