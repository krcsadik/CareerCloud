using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using CareerCloud.MVC.Utility;

namespace CareerCloud.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            //logger.Info("Uygulama başlatıldı");

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            /* not default code lines..added later manualy */
            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new RazorViewEngine());
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            List<Guid> applicationGuidStateList = new List<Guid>();
            var applicantId = "1F12F4FD-94B5-4DEE-E8A8-2203EEA60432"; //demo applicant
            HttpContext.Current.Session.Add("_ApplicantId", applicantId);
            HttpContext.Current.Session.Add("_ApplicationGuidList", applicationGuidStateList);

            Guid companyId = Guid.Parse("09327E8C-79DA-2A0A-2B84-027E71089F48"); //demo company
            HttpContext.Current.Session.Add("_CompanyId", companyId);
        }
    }
}
