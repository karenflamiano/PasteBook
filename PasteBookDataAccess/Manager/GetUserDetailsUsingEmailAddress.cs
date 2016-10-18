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
    public class GetUserDetailsUsingEmailAddress
    {
        List<Exception> ListOfException = new List<Exception>();
        public int GetAccountEmailAddress(string emailAddress)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities())
                {
                    result = (context.USERs.Where(x => x.EMAIL_ADDRESS == emailAddress).Select(x => x.ID).Single());
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
