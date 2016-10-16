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
    public class UserManager
    {
        List<Exception> ListOfException = new List<Exception>();
        public int AddUsertoDB(User user)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities())
                {
                    context.USERs.Add(Mapper.MapUserEntityToDBUserTable(user));
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
