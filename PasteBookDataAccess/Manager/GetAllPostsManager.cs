using PasteBookDataAccess.Entities;
using PasteBookDataAccess.Mappers;
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
        public List<Post> ListOfPosts(int userID)
        {
            List<Post> listOfPosts = new List<Post>();
            List<User> listOfFriends = new List<User>();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    listOfFriends = GetUserFriend(userID);
                    foreach (var item in listOfFriends)
                    {
                        listOfPosts = Mapper.MapRetrievePostFromDB(context.POSTs.Where(x => x.POSTER_ID == userID ||
                        x.PROFILE_OWNER_ID == userID || (x.POSTER_ID == item.ID &&
                        x.PROFILE_OWNER_ID == item.ID)).OrderByDescending(x => x.CREATED_DATE).Take(100).ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return listOfPosts;
        }

       private List<User> GetUserFriend(int UserID)
        {
            List<User> listOfFriend = new List<User>();
            List<Friend> IsFriend = new List<Friend>();
            int friendID = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    var result = context.FRIENDs.Where(x => x.ID == UserID || x.FRIEND_ID == UserID).ToList();

                    foreach (var item in result)
                    {
                        IsFriend.Add(new Friend()
                        {
                            ID = item.ID,
                            BLOCKED = Convert.ToChar(item.BLOCKED),
                            CREATED_DATE = item.CREATED_DATE,
                            FRIEND_ID = item.FRIEND_ID,
                            USER_ID = item.USER_ID,
                            REQUEST = Convert.ToChar(item.REQUEST)

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
                        listOfFriend = Mapper.MapUserListFromDB(context.USERs.Where(x => x.ID == friendID).ToList());
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
