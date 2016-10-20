﻿using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class LoginViewModel
    {
        public UserLoginModel LoginModel { get; set; }
        //public UserModel UserLoginModel { get; set; }
        public USER user { get; set; }

        public string confirmPassword { get; set; }
        public List<REF_COUNTRY> CountryList { get; set; }

    }
}