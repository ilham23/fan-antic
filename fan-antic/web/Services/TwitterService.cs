using System.Collections.Generic;
using System.Linq;
using LinqToTwitter;

namespace web.Services
{
    public class TwitterService
    {
        private readonly SingleUserAuthorizer _authorizer = new SingleUserAuthorizer
        {
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = "tiZXl8c82jD2oHOo06ybNL95E",
                ConsumerSecret = "IaIXywPwtU5jCHOTFs8wRXLzpKUmPgNgCzeuh2gbWGuFlRFqfj",
                AccessToken = "3226907072-HYk1qIBLUOCGUWC7DUluYtlqrVXdIp5rauoyOSt",
                AccessTokenSecret = "RseGBgwDEp5dQWAgHCyzTtaITg0oGmu8Qd5ApDKv9l0wF"
            }
        };

        private List<Status> _currentTwts;
        private List<string> lsFollowNames;

        public List<Status> GetMostRecent200HomeTimeline()
        {
            var twtContext = new TwitterContext(_authorizer);

            var twts = from twt in twtContext.Status
                       where twt.Type == StatusType.Home &&
                                        twt.Count == 5
                       select twt;

            _currentTwts = twts.ToList();
            return _currentTwts;
        }
    }
}