using System;
using System.Collections.Generic;
using System.Text;

namespace Geeter.Models
{
    public class AgentModel
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string companyName { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string bio { get; set; }
        public string photoUrl { get; set; }

        private string _photo;
        public string Photo
        {
            get {
                if (string.IsNullOrEmpty(photoUrl))
                {
                    _photo = "https://clipartart.com/images/animated-real-estate-clipart-6.jpg";
                }
                else
                {
                    _photo = $"http://dailyinfong.com/easebis/manage/storage/app/{photoUrl}";
                }
                return _photo; 
            }
            set { _photo = value; }
        }

        public string idUrl { get; set; }
        public string unique_code { get; set; }
        public string isSuspended { get; set; }
        public string isActive { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
