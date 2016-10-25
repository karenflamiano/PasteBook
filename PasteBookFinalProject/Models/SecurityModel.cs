using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class SecurityModel
    {
        public string EmailAddress { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}