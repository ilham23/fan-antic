using System.Web.Mvc;
using web.Models;
using web.Services;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var service = new TwitterService();
            var Model = new TwtList
            {
                Twts = service.GetCurrentTweets()
            };

            return View(Model);
        }

    }
}
