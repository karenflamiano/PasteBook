using PasteBookEntityFramework;
using PasteBookFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject
{
    public class Mapper
    {
        public List<VMPostUser> PostMapToModel(List<POST> postList, List<LIKE> likeList, List<COMMENT> commentList, List<USER> friendsList)
        {
            List<VMPostUser> model = new List<VMPostUser>();
            foreach (var item in postList)
            {
                model.Add(new VMPostUser()
                {
                    Content = item.CONTENT,
                    CreatedDate = item.CREATED_DATE,
                    PostID = item.ID,
                    PosterID = item.POSTER_ID,

                    LikeList = likeList,
                    CommentList = commentList,
                    FriendList = friendsList
                });
            }
            return model;

        }
    }
}