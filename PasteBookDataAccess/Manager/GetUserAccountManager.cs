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
    public class GetUserAccountManager
    {
        List<Exception> ListOfException = new List<Exception>();

        public User GetAccountEmailAddress(string emailAddress)
        {
            User result = new User();
            try
            {
                using (var context = new PASTEBOOKEntities())
                {
                    result = Mapper.MapDBUserTableToUserEntity(context.USERs.Where(x => x.EMAIL_ADDRESS == emailAddress).SingleOrDefault());
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
