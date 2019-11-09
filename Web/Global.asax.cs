using NServiceBus;
using NServiceBus.Installation.Environments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IBus bus;
           
        public static IBus Bus
        {
            get
            {
                return bus;
            }
        }

        protected void Application_Start()
        {
            Configure.Serialization.Xml();

            bus = Configure
                .With()
                .DefaultBuilder()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.Contains("Commands"))
                .UseTransport<Msmq>()
                .UnicastBus()
                .SendOnly();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
