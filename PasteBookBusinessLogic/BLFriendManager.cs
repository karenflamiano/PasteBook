using PasteBookDataAccess;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class BLFriendManager
    {
        FriendManager friendManager = new FriendManager();
        PasteBookDataAccess<FRIEND> friend = new PasteBookDataAccess<FRIEND>();

         public List<FRIEND> UserFriends(int ID)
        {
            return friendManager.GetAllFriends(ID);
        }

        public List<USER> UserFriendsInformation(int ID)
        {
            return friendManager.FriendsInformation(ID);
        }

        public string FriendRequest(int ID, int accountID)
        {
            var friend = friendManager.GetAllFriends(ID);
            string friendshipStatus = "";
            
            if(ID == accountID)
            {
                friendshipStatus = "";
            }
            else if (friend.Any(x => x.USER_ID == ID && x.FRIEND_ID == accountID && x.REQUEST == "Y"))
            {
                friendshipStatus = "CONFIRM REQUEST";

            }
            else if (friend.Any(x => x.FRIEND_ID == ID && x.USER_ID == accountID && x.REQUEST == "Y"))
            {
                friendshipStatus = "SENT REQUEST";
            }
            else if (friend.Any(x => ((x.USER_ID == ID && x.FRIEND_ID == accountID)
                                     || (x.USER_ID == accountID && x.FRIEND_ID == ID))
                                     && x.REQUEST == "N"))
            {
                friendshipStatus = "FRIENDS";
            }
            else if (!friend.Any(x => x.USER_ID == ID && x.FRIEND_ID == accountID))
            {
                friendshipStatus = "NOT FRIENDS";
            }
            else
            {
                friendshipStatus = "NO REQUEST";
            }
            return friendshipStatus;
        }

        public int AddFriend(FRIEND friendModel)
        {
            int result = 0;
            result = friend.Add(friendModel);
            return result;
        }

        public int ConfirmFriend(int userID, int profileID)
        {
            int result = 0;
            
            result = friendManager.UpdateFriend(userID, profileID);
            return result;
        }
    }
}
