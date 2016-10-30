using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class UserLoginModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} must not exceed {1} characters.")]
        [DataType(DataType.EmailAddress)]
        public string LoginEmail { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "{0} must not exceed {1} characters.")]
        public string LoginPassword { get; set; }
    }
}