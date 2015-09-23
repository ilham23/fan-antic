using System;
using System.Collections.Generic;
using System.Web;
using LinqToTwitter;
using web.Services;

namespace web.Common
{
    public class ApplicationData
    {
        public static object GetApplicationData(string objectName)
        {
            object result = null;
            if (HttpContext.Current != null)
            {
                result = HttpContext.Current.Application.Get(objectName);
            }

            if (result == null)
            {
                switch (objectName)
                {
                    case CacheParam.CacheTimelineTweet:
                        result = GetTimelineTwts();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(paramName: "objectName");
                }
            }

            if (HttpContext.Current != null)
            {
                HttpContext.Current.Application.Set(objectName, result);
            }

            return result;
        }

        private static List<Status> GetTimelineTwts()
        {

            var service = new TwitterService();
            var resultList = service.GetMostRecent200HomeTimeline();

            return resultList;
        }
    }
}