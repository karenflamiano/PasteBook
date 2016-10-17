using PasteBookDataAccess.Entities;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class GetUserAccount
    {
        List<Exception> ListOfException = new List<Exception>();
        public bool GetAccount(string emailAddress)
        {
            bool result = false;
            try
            {
                using (var context = new PASTEBOOKEntities())
                {
                    result = context.USERs.Any(x => x.EMAIL_ADDRESS == emailAddress);
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
