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
        public List<POST> NewsFeedPosts(int ID)
        {
            return finalPost.NewsFeedListOfPosts(ID);
        }
        
    }
}
