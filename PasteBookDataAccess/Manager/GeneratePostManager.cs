
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

        public int AddPostToDB(POST post)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    context.POSTs.Add(post);
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
