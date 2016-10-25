using PasteBookDataAccess.Manager;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class BLLikeManager
    {
        LikeManager likeManager = new LikeManager();
        public int AddLike(LIKE like)
        {
            int result = 0;
            result = likeManager.AddLikeToDB(like);
            return result;
        }

        //public List<LIKE> ListOfLike(int ID)
        //{
        //    return likeManager.listOfUserLiked(ID);
        //}
    }
}
