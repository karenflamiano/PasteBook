
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class GetAllPostsManager
    {
        List<Exception> ListOfException = new List<Exception>();
        
        public List<POST> ListOfPosts(int userID)
        {
            List<POST> listOfPosts = new List<POST>();
            List<USER> listOfFriends = new List<USER>();
            List<POST> finalListOfPost = new List<POST>();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    var userPosts =  context.POSTs.Where(x => x.POSTER_ID == userID || x.PROFILE_OWNER_ID == userID);

                    foreach (var userPost in userPosts)
                    {
                        listOfPosts.Add(new POST()
                        {
                            CONTENT = userPost.CONTENT,
                            CREATED_DATE = userPost.CREATED_DATE,
                            ID = userPost.ID,
                            POSTER_ID = userPost.POSTER_ID,
                            PROFILE_OWNER_ID = userPost.PROFILE_OWNER_ID
                        });

                    }
                    listOfFriends = GetUserFriend(userID);

                    foreach (var item in listOfFriends)
                    {
                       var friendsPosts = context.POSTs.Where(x => x.POSTER_ID == item.ID || x.PROFILE_OWNER_ID == item.ID).ToList();
                        foreach (var friendPost in friendsPosts)
                        {
                            listOfPosts.Add(new POST()
                            {
                                CONTENT = friendPost.CONTENT,
                                CREATED_DATE = friendPost.CREATED_DATE,
                                ID = friendPost.ID,
                                POSTER_ID = friendPost.POSTER_ID,
                                PROFILE_OWNER_ID = friendPost.PROFILE_OWNER_ID
                            });
                        }
                    }

                    finalListOfPost = listOfPosts.OrderByDescending(x => x.CREATED_DATE).Take(100).ToList();
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return finalListOfPost;
        }

       private List<USER> GetUserFriend(int UserID)
        {
            List<USER> listOfFriend = new List<USER>();
            List<FRIEND> IsFriend = new List<FRIEND>();
            int friendID = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    var result = context.FRIENDs.Where(x => x.USER_ID == UserID || x.FRIEND_ID == UserID).ToList();

                    foreach (var item in result)
                    {
                        IsFriend.Add(new FRIEND()
                        {
                            ID = item.ID,
                            BLOCKED =item.BLOCKED,
                            CREATED_DATE = item.CREATED_DATE,
                            FRIEND_ID = item.FRIEND_ID,
                            USER_ID = item.USER_ID,
                            REQUEST = item.REQUEST

                        });
                    }

                    foreach (var item in IsFriend)
                    {
                        if(item.USER_ID == UserID)
                        {
                            friendID = item.FRIEND_ID;
                        }
                        else if(item.FRIEND_ID == UserID)
                        {
                            friendID = item.USER_ID;
                        }
                        var list = context.USERs.Where(x => x.ID == friendID).ToList();

                        foreach (var friend in list)
                        {
                            listOfFriend.Add(new USER()
                            {
                                ID = friend.ID,
                                ABOUT_ME = friend.ABOUT_ME,
                                BIRTHDAY = friend.BIRTHDAY,
                                FIRST_NAME = friend.FIRST_NAME,
                                LAST_NAME = friend.LAST_NAME,
                                USER_NAME = friend.USER_NAME
                            });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return listOfFriend;
        }
    }
}
