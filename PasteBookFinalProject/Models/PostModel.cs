using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class PostModel
    {
        public int PostID { get; set; }
        public DateTime PostCreatedDate { get; set; }
        public string PostContent { get; set; }
        public int PostProfileOwnerID { get; set; }
        public int PostPosterID { get; set; }
    }
}