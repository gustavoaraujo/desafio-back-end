using BackEndInfoglobo.Controller;
using BackEndInfoglobo.Service.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BackEndInfoglobo.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Thread t = new Thread(AtualizarFeed);
            t.IsBackground = true;
            t.Start();
        }

        public void AtualizarFeed()
        {
            while (true)
            {
                var feed = new Crawler().Crawl();

                if (feed.Contains("Response Error: "))
                    FeedController.feed = feed;

                Thread.Sleep(60000);
            }
        }
    }
}
