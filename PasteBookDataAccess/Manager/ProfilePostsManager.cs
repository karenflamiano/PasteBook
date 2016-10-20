
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class ProfilePostsManager
    {
        List<Exception> ListOfException = new List<Exception>();

        public List<POST> ProfileListOfPosts(int userID)
        {
            List<POST> listOfPosts = new List<POST>();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    var result = context.POSTs.Where(x => x.POSTER_ID == userID || x.PROFILE_OWNER_ID == userID).ToList();
                    foreach (var item in result)
                    {

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
