using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class PostManager
    {
        FriendManager friendManager = new FriendManager();

        List<Exception> ListOfException = new List<Exception>();

        public int AddPostToDB(POST post)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    context.POSTs.Add(post);
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return result;
        }

        public List<POST> NewsFeedListOfPosts(List<FRIEND> friendsList,int userID, int profileID)
        {
            List<POST> listOfPosts = new List<POST>();
            int friendID = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    listOfPosts = context.POSTs.Include("USER").Include("USER1").Include("LIKEs").Where(x => x.POSTER_ID == userID || x.PROFILE_OWNER_ID == userID).ToList();
                    foreach (var item in friendsList)
                    {
                        var friendsPosts = context.POSTs.Include("USER").Include("USER1").Include("LIKEs").Where(x => x.POSTER_ID == item.ID || x.PROFILE_OWNER_ID == item.ID).ToList();

                        if (item.USER_ID == userID)
                        {
                            friendID = item.FRIEND_ID;
                        }
                        else if (item.FRIEND_ID == userID)
                        {
                            friendID = item.USER_ID;
                        }

                        foreach (var friendPost in friendsPosts)
                        {
                            listOfPosts.Add(new POST()
                            {
                                CONTENT = friendPost.CONTENT,
                                CREATED_DATE = friendPost.CREATED_DATE,
                                ID = friendPost.ID,
                                POSTER_ID = friendPost.POSTER_ID,
                                PROFILE_OWNER_ID = friendPost.PROFILE_OWNER_ID,
                                COMMENTs = friendPost.COMMENTs,
                                LIKEs = friendPost.LIKEs,
                                NOTIFICATIONs = friendPost.NOTIFICATIONs,
                                USER = friendPost.USER,
                                USER1 = friendPost.USER1
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return listOfPosts.OrderByDescending(x => x.CREATED_DATE).Take(100).ToList();
        }
    }
}
