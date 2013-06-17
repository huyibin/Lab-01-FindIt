using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using FindIt.Web.UnityExtensions;
using System.Security.Principal;
using FindIt.Web.Models;
using System.Web.Security;
using FindIt.Web.Authentication;
using FindIt.Data;

namespace FindIt.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IUnityContainer container;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }

        public override void Init()
        {
            //this.PostAuthenticateRequest += this.PostAuthenticateRequestHandler;
            //this.EndRequest += this.EndRequestHandler;

            base.Init();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //
            InitializeDependencyInjectionContainer();
            InitializeDatabase();
        }

        #region Privates
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "This should survive the lifetime of the application.")]
        private static void InitializeDependencyInjectionContainer()
        {
            container = new UnityContainerFactory().CreateConfiguredContainer();
            var serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private void EndRequestHandler(object sender, EventArgs e)
        {
            // This is a workaround since subscribing to HttpContext.Current.ApplicationInstance.EndRequest 
            // from HttpContext.Current.ApplicationInstance.BeginRequest does not work. 
            IEnumerable<UnityHttpContextPerRequestLifetimeManager> perRequestManagers =
                container.Registrations
                    .Select(r => r.LifetimeManager)
                    .OfType<UnityHttpContextPerRequestLifetimeManager>()
                    .ToArray();

            foreach (var manager in perRequestManagers)
            {
                manager.Dispose();
            }
        }

        private void PostAuthenticateRequestHandler(object sender, EventArgs e)
        {
            HttpCookie authCookie = this.Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (IsValidAuthCookie(authCookie))
            {
                var formsAuthentication = ServiceLocator.Current.GetInstance<IFormsAuthentication>();

                var ticket = formsAuthentication.Decrypt(authCookie.Value);
                var appIdentity = new AppIdentity(ticket);
                this.Context.User = new GenericPrincipal(appIdentity, null);

                // Reset cookie for a sliding expiration.
                formsAuthentication.SetAuthCookie(this.Context, ticket);
            }
        }

        private static bool IsValidAuthCookie(HttpCookie authCookie)
        {
            return authCookie != null && !String.IsNullOrEmpty(authCookie.Value);
        }

        private static void InitializeDatabase()
        {
            var repositoryInitializer = ServiceLocator.Current.GetInstance<IRepositoryInitializer>();
            repositoryInitializer.Initialize();
        }
        #endregion
    }
}