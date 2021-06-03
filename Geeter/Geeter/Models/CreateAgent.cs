using System;
using System.Collections.Generic;
using System.Text;

namespace Geeter.Models
{
    public class CreateAgent
    {
        public string id { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string name { get; set; }
        public string phone { get; set; }
        public string companyName { get; set; }
        public string companyAddress { get; set; }
        public string state { get; set; }
        public string lga { get; set; }
        public string coverageArea { get; set; }
        public string imageUrl { get; set; }
        public int searchedTimes { get; set; }
        public string postedBy { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
