using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class LoginViewModel
    {
        public UserLoginModel LoginModel { get; set; }
        public USER user { get; set; }
        public string CONFIRM_PASSWORD { get; set; }
        public List<REF_COUNTRY> CountryList { get; set; }

    }
}