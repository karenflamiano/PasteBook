using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class VMPostUser
    {
        public UserModel UserModelDetails { get; set; }
        public PostModel CreatePost { get; set; }
        public List<PostModel> ListOfPost { get; set; }
    }
}