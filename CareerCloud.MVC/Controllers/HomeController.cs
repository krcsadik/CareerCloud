using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerCloud.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //ViewBag.BackgroudImage = " style = \"background-image: \"~/Content/Images/CareerCloudHomeScreen.jpg\" \"";
            //@ViewBag.BackgroundImageStyle = @"
            //<style>
            //    body{ background:url(Content/Images/CareerCloudHomeScreen.jpg) no-repeat; background-size:100%  }
            //</style>" ;
            @ViewBag.BackgroundImageStyle = " style=\"background-image: url(~/Content/Images/CareerCloudHomeScreen.jpg) no-repeat; background-size:100%\"";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}