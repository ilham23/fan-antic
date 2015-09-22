using System.Web.Mvc;
using web.Services;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = new TwitterService();

            var twts = service.GetMostRecent200HomeTimeline();

            return View("Index", twts);
        }

        public ActionResult Default()
        {
            return View();
        }
    }
}
