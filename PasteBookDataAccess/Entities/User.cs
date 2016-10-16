using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string SALT { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public DateTime BIRTHDAY { get; set; }
        public int COUNTRY_ID { get; set; }
        public string MOBILE_NO { get; set; }
        public char GENDER { get; set; }
        public byte[] PROFILE_PIC { get; set; }
        public DateTime DATE_CREATED { get; set; }
        public string ABOUT_ME { get; set; }
        public string EMAIL_ADDRESS { get; set; }
    }
}
