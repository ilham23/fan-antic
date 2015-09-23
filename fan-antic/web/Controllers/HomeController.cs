using System.Collections.Generic;
using System.Net.Mime;
using System.Web.Mvc;
using LinqToTwitter;
using web.Common;
using web.Services;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var twts = ApplicationData.GetApplicationData(CacheParam.CacheTimelineTweet) as List<Status>;

            return View("Index", twts);
        }

        public ActionResult Default()
        {
            return View();
        }
    }
}
