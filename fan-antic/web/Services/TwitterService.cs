using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToTwitter;

namespace web.Services
{
    public class TwitterService
    {
        private SingleUserAuthorizer authorizer = new SingleUserAuthorizer
        {
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = "tiZXl8c82jD2oHOo06ybNL95E",
                ConsumerSecret = "IaIXywPwtU5jCHOTFs8wRXLzpKUmPgNgCzeuh2gbWGuFlRFqfj",
                AccessToken = "3226907072-HYk1qIBLUOCGUWC7DUluYtlqrVXdIp5rauoyOSt",
                AccessTokenSecret = "RseGBgwDEp5dQWAgHCyzTtaITg0oGmu8Qd5ApDKv9l0wF"
            }
        };

        private List<Status> currentTwts;
        private List<string> lsFollowNames;

        public TwitterService()
        {
            GetMostRecent200HomeTimeline();
        }

        private void GetMostRecent200HomeTimeline()
        {
            var twtContext = new TwitterContext(authorizer);

            var twts = from twt in twtContext.Status
                       where twt.Type == StatusType.Home &&
                                        twt.Count == 200
                       select twt;

            currentTwts = twts.ToList();
        }

        public List<Status> GetCurrentTweets()
        {
            return currentTwts;
        } 

        
    }
}