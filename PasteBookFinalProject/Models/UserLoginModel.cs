using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class UserLoginModel
    {
        //[Required]
        //[StringLength(254, ErrorMessage = "{0} must not exceed {1} characters.")]
        //[DataType(DataType.EmailAddress)]
        public string LoginEmail { get; set; }


        //[Required]
        //[DataType(DataType.Password)]
        //[StringLength(20, MinimumLength = 6, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string LoginPassword { get; set; }
    }
}