using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class CommentViewModel
    {
        public COMMENT comment { get; set; }
        public string fullname { get; set; }
    }
}