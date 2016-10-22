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
        //public UserModel UserLoginModel { get; set; }
        public USER user { get; set; }


        //[Required]
        //[Required(ErrorMessage = "Confirm Password field is required")]
        //[DataType(DataType.Password)]
        //[StringLength(20, MinimumLength = 6, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        //[Compare("PASSWORD", ErrorMessage = "Password do not match")]
        public string confirmPassword { get; set; }
        public List<REF_COUNTRY> CountryList { get; set; }

    }
}