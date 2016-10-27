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
        PostManager postManager = new PostManager();

        public int AddPost(POST post)
        {
            int result = 0;
            result = postManager.AddPostToDB(post);
            return result;
        }
        public List<POST> NewsFeedPosts(List<FRIEND> listOfFriend, int userID, int profileOwnerID)
        {
            return postManager.NewsFeedListOfPosts(listOfFriend,userID, profileOwnerID);
        }

        public List<POST> TimeLinePosts(int userID)
        {
            return postManager.TimelineListOfPosts(userID);
        }

    }
}
