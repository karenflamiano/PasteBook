using PasteBookDataAccess.Manager;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class BLPostManager
    {
        PostManager finalPost = new PostManager();

        public int AddPost(POST post)
        {
            int result = 0;
            result = finalPost.AddPostToDB(post);
            return result;
        }
        public List<POST> NewsFeedPosts(List<FRIEND> listOfFriend, int userID, int profileOwnerID)
        {
            return finalPost.NewsFeedListOfPosts(listOfFriend,userID, profileOwnerID);
        }
        
    }
}
