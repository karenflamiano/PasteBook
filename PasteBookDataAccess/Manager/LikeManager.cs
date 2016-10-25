using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class LikeManager
    {
        public List<Exception> ListOfException = new List<Exception>();
        public int AddLikeToDB(LIKE like)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    context.LIKEs.Add(like);
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return result;
        }

        public List<LIKE> ListOfUserLiked(int postID)
        {
            List<LIKE> listOfLike = new List<LIKE>();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    listOfLike = context.LIKEs.Include("USER").Where(x => x.POST_ID == postID).Take(100).ToList();
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return listOfLike;
        }
        

        public int UnlikePost(int postID, int userID)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    context.POSTs.Where(x => x.ID == postID).SingleOrDefault();
                    result = context.SaveChanges();
                    
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return result;
        }

    }
}
