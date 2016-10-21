using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess
{
    public class CommentManager
    {
        public List<Exception> ListOfException = new List<Exception>();
        public int AddCommentToDB(COMMENT comment)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    context.COMMENTs.Add(comment);
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return result;
        }

        public List<COMMENT> ListOfComment(int postID)
        {
            List<COMMENT> listOfPosts = new List<COMMENT>();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    var result = context.COMMENTs.Where(x => x.ID == postID).ToList();
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return listOfPosts;
        }
    }
}
