using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ichamn
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            SetupWakeUpTimer();
        }

        private void SetupWakeUpTimer()
        {
            var aTimer = new Timer();

            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += OnTimedEvent;

            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 300000;
            aTimer.Enabled = true;
        }

        // Specify what you want to happen when the Elapsed event is 
        // raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows; Windows NT 5.1; rv:1.9.2.4) Gecko/20100611 Firefox/3.6.4");
                wc.DownloadString("http://www.ichamn.com/home/up");
            }
        }
    }
}