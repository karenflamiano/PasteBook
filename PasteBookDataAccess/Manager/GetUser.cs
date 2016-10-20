
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class GetUser
    {
        List<Exception> ListOfException = new List<Exception>();
        public int AddUsertoDB(USER user)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    user.DATE_CREATED = DateTime.Now;
                    user.BIRTHDAY = user.BIRTHDAY.Date;
                    context.USERs.Add(user);
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }

            return result;

        }
        
        public bool CheckIfUsernameExists (string username)
        {
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    return context.USERs.Any(x => x.USER_NAME == username);
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
                return false;
            }
        }

        public bool CheckIfEmailExists(string emailAddress)
        {
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    return context.USERs.Any(x => x.EMAIL_ADDRESS == emailAddress);
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
                return false;
            }
        }
    }
    
}
