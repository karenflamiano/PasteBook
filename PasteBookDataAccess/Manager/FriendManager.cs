using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
    public class FriendManager
    {
        List<Exception> listOfException = new List<Exception>();
        public List<FRIEND> GetAllFriends(int ID)
        {
            List<FRIEND> friendList = new List<FRIEND>();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    var ListUser = context.FRIENDs.Where(x => x.USER_ID == ID && x.REQUEST == "Y").ToList();
                    foreach (var userItem in ListUser)
                    {
                        friendList.Add(userItem);
                    }

                    var ListFriend = context.FRIENDs.Where(x => x.FRIEND_ID == ID && x.REQUEST == "Y").ToList();
                    foreach (var friendItem in ListFriend)
                    {
                        friendList.Add(friendItem);
                    }
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }

            return friendList;
        }

        public List<USER> FriendsInformation(int userID)
        {
            List<USER> friendInformation = new List<USER>();
            List<FRIEND> friendList = GetAllFriends(userID);
            int friendID = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    foreach (var item in friendList)
                    {
                        if (item.USER_ID == userID)
                        {
                            friendID = item.FRIEND_ID;
                        }
                        else if (item.FRIEND_ID == userID)
                        {
                            friendID = item.USER_ID;
                        }

                        var list = context.USERs.Where(x => x.ID == friendID).ToList();

                        foreach (var friend in list)
                        {
                            friendInformation.Add(new USER()
                            {
                                ID = friend.ID,
                                USER_NAME = friend.USER_NAME,
                                FIRST_NAME = friend.FIRST_NAME,
                                LAST_NAME = friend.LAST_NAME,
                                DATE_CREATED = friend.DATE_CREATED,
                                GENDER = friend.GENDER,
                                BIRTHDAY = friend.BIRTHDAY,
                                EMAIL_ADDRESS = friend.EMAIL_ADDRESS,
                                ABOUT_ME = friend.ABOUT_ME,
                                COUNTRY_ID = friend.COUNTRY_ID,
                                MOBILE_NO = friend.MOBILE_NO,
                                PROFILE_PIC = friend.PROFILE_PIC

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }

            return friendInformation;
        }


    }
}
