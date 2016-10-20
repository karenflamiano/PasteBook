
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class GetUserDetailsUsingEmailAddress
    {
        List<Exception> ListOfException = new List<Exception>();

        public USER GetAccountEmailAddress(string emailAddress)
        {
            USER result = new USER();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    result = context.USERs.Where(x => x.EMAIL_ADDRESS == emailAddress).SingleOrDefault();
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
