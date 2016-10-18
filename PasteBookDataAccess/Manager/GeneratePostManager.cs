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
    public class GeneratePostManager
    {
        List<Exception> ListOfException = new List<Exception>();
        public int AddPostToDB(Post post)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities())
                {
                    POST newPost = new POST();
                    newPost.POSTER_ID = post.POSTER_ID;
                    newPost.PROFILE_OWNER_ID = post.PROFILE_OWNER_ID;
                    newPost.CONTENT = post.CONTENT;
                    post.CREATED_DATE = DateTime.Now;
                    context.POSTs.Add(Mapper.MapPostEntityToDBPostTable(post));
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
