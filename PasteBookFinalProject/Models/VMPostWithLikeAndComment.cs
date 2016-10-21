using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Models
{
    public class VMPostWithLikeAndComment
    {
        public List<VMPostUser> postList;

        public VMPostWithLikeAndComment()
        {
            postList = new List<VMPostUser>();
        }
    }
}