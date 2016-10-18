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

        public List<Post> ListOfPosts()
        {
            List<Post> listOfPosts = new List<Post>();

            try
            {
                using (var context = new PASTEBOOKEntities())
                {
                    foreach (var item in context.POSTs.ToList())
                    {
                        listOfPosts.Add(Mapper.MapDBPostTableToPostEntity(item));
                    }
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
