using PasteBookDataAccess.Manager;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class PostManager
    {
        GetAllPostsManager getPostManager = new GetAllPostsManager();
        GeneratePostManager postManager = new GeneratePostManager();
        public List<POST> NewsFeedPosts(int ID)
        {
            return getPostManager.ListOfPosts(ID);
        }
        
        public void AddPost(POST post)
        {
            postManager.AddPostToDB(post);
        }
    }
}
