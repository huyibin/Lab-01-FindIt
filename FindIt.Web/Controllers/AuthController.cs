using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindIt.Web.Authentication;
using FindIt.Domain.Contracts;
using Microsoft.Practices.Unity;

namespace FindIt.Web.Controllers
{
    public class AuthController : Controller {
        private readonly IFormsAuthentication formsAuthentication;
        private readonly IUserServices userServices;


        [InjectionConstructor]
        public AuthController( IFormsAuthentication formsAuthentication,
                              IUserServices userServices) {
            this.formsAuthentication = formsAuthentication;
            this.userServices = userServices;
        }

        //
        // GET: /Auth/
        
        public ActionResult SignIn() {
            return RedirectToAction("Index", "Company");
        }

        public ActionResult SignInWithProvider(string providerUrl) {
            return RedirectToAction("Index", "Company");
        }

        public ActionResult SignInResponse(string returnUrl) {
            return View();
        }

        public ActionResult SignOut() {
            this.formsAuthentication.Signout();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
