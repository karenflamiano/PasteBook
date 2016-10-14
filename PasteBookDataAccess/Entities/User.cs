using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Entities
{
    public class User
    {
        public int U_ID { get; set; }
        public string U_UserName { get; set; }
        public string U_Password { get; set; }
        public string U_Salt { get; set; }
        public string U_FirstName { get; set; }
        public string U_LastName { get; set; }
        public DateTime U_BirthDate { get; set; }
        public int U_CountryID { get; set; }
        public string U_MobileNumber { get; set; }
        public string U_Gender { get; set; }
        public byte U_ProfilePicture { get; set; }
        public DateTime U_DateCreated { get; set; }
        public string U_AboutMe { get; set; }
        public string U_EmailAddress { get; set; }
    }
}
