using BLL.Infrastructure;
using MemeShop.Utilities;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MemeShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule module = new NinjectUtil();
            NinjectModule server = new ServiceNinjectModule("DefaulConnection");
            var kernel = new StandardKernel(module, server);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
