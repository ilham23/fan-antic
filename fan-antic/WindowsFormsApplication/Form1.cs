using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToTwitter;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
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
        
        public Form1()
        {
            InitializeComponent();

            GetMostRecent200HomeTimeline();
            listBox2.Items.Clear();
            currentTwts.ForEach(twt =>
                listBox2.Items.Add(twt.Text));

            getSideBarList(GetFollower()).ForEach(name =>
                listBox1.Items.Add(name));
        }

        private void GetMostRecent200HomeTimeline()
        {
            var twtContext = new TwitterContext(authorizer);

            var twts = from twt in twtContext.Status
                where twt.Type == StatusType.Home &&
                                 twt.Count == 20
                select twt;

            currentTwts = twts.ToList();
        }

        private List<string> GetFollower()
        {
            List<string> results = new List<string>();

            var twtContext = new TwitterContext(authorizer);

            var temp = Enumerable.FirstOrDefault(
                from friend in twtContext.Friendship
                where friend.Type == FriendshipType.FollowersList &&
                      //friend.ScreenName == "SBY" &&
                      friend.Count == 200
                select friend);

            if (temp != null)
            {
                temp.Users.ToList().ForEach(user => results.Add(user.Name));

                while (temp != null && temp.CursorMovement.Next != 0)
                {
                    temp = Enumerable.FirstOrDefault(
                        from friend in twtContext.Friendship
                        where friend.Type == FriendshipType.FollowersList &&
                              //friend.ScreenName == "SBY" &&
                              friend.Count == 200 &&
                              friend.Cursor == temp.CursorMovement.Next
                        select friend);

                    if(temp!= null) temp.Users.ToList().ForEach(user => results.Add(user.Name));
                }
            }

            return results;
        }

        private List<string> getSideBarList(List<string> inputNames)
        {
            List<string> results = new List<string>();

            foreach (string name in inputNames)
            {
                int twtCount = currentTwts.Count(twt =>
                    twt.User.Name == name);

                if (twtCount > 0)
                {
                    results.Add(string.Format("{0} ({1})", name, twtCount));
                }
                else
                {
                    results.Add(string.Format("{0}", name));
                }
            }

            return results;
        }
    }
}
