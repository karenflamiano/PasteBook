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
        //public List<POST> listOfPost { get; set; }
        public int PostID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int ProfileOwnerID { get; set; }
        public int PosterID { get; set; }


        public List<COMMENT> CommentList { get; set; }
        public List<LIKE> LikeList { get; set; }
        public List<USER> FriendList { get; set; }


        string fullname { get; set; }
        public byte[] profilePicture { get; set; }
        public List<USER> UserList { get; set; }

    }
}