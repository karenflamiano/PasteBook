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

       public List<FRIEND> UserFriends(int ID)
        {
            return friendManager.GetAllFriends(ID);
        }

        public List<USER> UserFriendsInformation(int ID)
        {
            return friendManager.FriendsInformation(ID);
        }
    }
}
