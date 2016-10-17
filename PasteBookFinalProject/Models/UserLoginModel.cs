using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class UserLoginModel
    {
        public string LoginUsername { get; set; }
        public string LoginPassword { get; set; }
        public string LoginSalt { get; set; }
    }
}