using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class VMPostUser
    {
        public USER UserModelDetails { get; set; }
        [Required(ErrorMessage ="Can't Post Nothin' Nigga!")]
        public POST CreatePost { get; set; }
        public List<POST> ListOfPost { get; set; }
    }
}