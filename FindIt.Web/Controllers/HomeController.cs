using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindIt.Domain.Contracts;
using Microsoft.Practices.ServiceLocation;
using FindIt.Domain.Handlers.Digests;

namespace FindIt.Web.Controllers {
    public class HomeController : AuthorizedController {

        public HomeController(IUserServices userServices,
            IServiceLocator serviceLocator)
            : base(userServices, serviceLocator) {
        }
        //
        // GET: /Home/

        public ActionResult Index() {
            return View();
        }

        public ActionResult Register() {
            return View();
        }

    }
}
