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
        
        public Form1()
        {
            InitializeComponent();

            GetMostRecent200HomeTimeline();
            listBox2.Items.Clear();
            currentTwts.ForEach(twt =>
                listBox2.Items.Add(twt.Text));
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
    }
}
