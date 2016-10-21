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
        public POST Post { get; set; }
        string fullname { get; set; }
        public byte[] profile_picture { get; set; }
        public List<COMMENT> CommentList { get; set; }
        public List<LIKE> LikeList { get; set; }
    }
}