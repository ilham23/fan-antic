using System.Collections.Generic;
using LinqToTwitter;

namespace web.Models
{
    public class TwtModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }

    public class TwtList
    {
        public List<Status> Twts;
    }
}