using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
    public class NotificationManager
    {
        List<Exception> ListOfException = new List<Exception>();

        public int AddNotification(NOTIFICATION notif)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    context.NOTIFICATIONs.Add(notif);
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
