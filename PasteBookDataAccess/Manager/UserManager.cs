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

        public USER GetUserDetailsUsingID(int ID)
        {
            USER result = new USER();
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    result = context.USERs.Where(x => x.ID == ID).SingleOrDefault();
                }

            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return result;
        }


        public int GetIDUSingEmailAddress(string emailAddress)
        {
            int result = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
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

        public bool CheckIfUsernameExists(string username)
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

        public int UpdateUserInformation(USER user, int userID)
        {
            int numberUpdated = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {

                    USER record = context.USERs.Where(x => x.ID == userID).SingleOrDefault();
                    if (record != null)
                    {
                        record.USER_NAME = user.USER_NAME;
                        record.FIRST_NAME = user.FIRST_NAME;
                        record.LAST_NAME = user.LAST_NAME;
                        record.BIRTHDAY = user.BIRTHDAY;
                        record.COUNTRY_ID = user.COUNTRY_ID;
                        record.MOBILE_NO = user.MOBILE_NO;
                        record.GENDER = user.GENDER;
                        numberUpdated = context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);

            }
            return numberUpdated;
        }

        public int UpdateUserCredentials(USER user, int userID)
        {
            int numberUpdated = 0;
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {

                    USER record = context.USERs.Where(x => x.ID == userID).SingleOrDefault();
                    if (record != null)
                    {
                        record.EMAIL_ADDRESS = user.EMAIL_ADDRESS;
                        record.PASSWORD = user.PASSWORD;
                        numberUpdated = context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);

            }
            return numberUpdated;
        }

    }
}
