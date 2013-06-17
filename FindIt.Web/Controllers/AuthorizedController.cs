using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindIt.Domain.Contracts;
using Microsoft.Practices.ServiceLocation;
using FindIt.Domain.Models;

namespace FindIt.Web.Controllers {
    public class AuthorizedController : Controller {
        protected readonly IUserServices UserServices;
        private readonly IServiceLocator serviceLocator;

        public AuthorizedController(IUserServices userServices, IServiceLocator serviceLocator) {
            if (userServices == null)
                throw new ArgumentNullException("userServices");
            this.UserServices = userServices;
            this.serviceLocator = serviceLocator;
        }

        /// <summary>
        /// Retrieves the CurrentUserId as stored in the <see cref="MileageStatsIdentity"/>
        /// </summary>
        /// <remarks>
        /// Using this method requires the user to be authorized.
        /// </remarks>
        protected int CurrentUserId {
            get { return this.User.AppIdentity().UserId; }
        }

        private User currentUser;

        /// <summary>
        /// Returns the current user or recovers the user from the <see cref="MileageStatsIdentity"/>.
        /// </summary>
        /// <remarks>
        /// Using this method requires the user to be authorized.
        /// </remarks>
        public User CurrentUser {
            get {
                return this.currentUser ??
                       (this.currentUser = this.UserServices.GetUserFromIdentity(this.User.AppIdentity()));
            }
        }

        protected T Using<T>() where T : class {
            var handler = serviceLocator.GetInstance<T>();
            if (handler == null) {
                throw new NullReferenceException("Unable to resolve type with service locator; type " + typeof(T).Name);
            }
            return handler;
        }
    }
}
