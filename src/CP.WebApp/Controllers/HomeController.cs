using CP.WebApp.App_Code;
using System.Web.Mvc;

namespace CP.WebApp.Controllers
{
	public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page." + AspNetUserId;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page." + AspNetUserId;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page." ;

            return View();
        }
    }
}