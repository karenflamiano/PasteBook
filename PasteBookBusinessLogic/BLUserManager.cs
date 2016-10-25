using PasteBookDataAccess;
using PasteBookDataAccess.Manager;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PasteBookBusinessLogic
{
    public class BLUserManager
    {
        UserManager userManager = new UserManager();
        PasswordManager pwdManager = new PasswordManager();
        PasteBookDataAccess<USER> userDataAccess = new PasteBookDataAccess<USER>();
      

        public void AddUserAccount(USER user)
        {
            user.SALT = SaltGenerator.GetSaltString();
            var stringPassword = user.PASSWORD;
            user.PASSWORD = pwdManager.GetPasswordHash(stringPassword + user.SALT);
            userManager.AddUsertoDB(user);
        }
        
        public bool CheckIfUsernameExists(string username)
        {
            bool returnValue;
            returnValue = userManager.CheckIfUsernameExists(username);
            return returnValue;
        }

        public bool CheckIfEmailExists(string email)
        {
            bool returnValue;
            returnValue = userManager.CheckIfEmailExists(email);
            return returnValue;
        }

        public bool CheckIfEmailAddressExists(USER user)
        {
            bool result = false;
            if (user.EMAIL_ADDRESS != null)
            {
                if (userManager.CheckIfEmailExists(user.EMAIL_ADDRESS))
                {
                    result = PasswordInputAndPasswordFromDBMatch(user.EMAIL_ADDRESS, user.PASSWORD);
                    return result;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return result;
            }
        }
        
        //used email to retreive the user details, GetAccountEmailAddress
        public bool PasswordInputAndPasswordFromDBMatch(string email, string password)
        {
            bool result;
            USER user = userManager.GetAccountEmailAddress(email);
            return result = IsPasswordMatch(password, user.SALT, user.PASSWORD);
        }


        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == pwdManager.GetPasswordHash(finalString);
        }


        public int GetAccountIDUsingEmail(string emailAddress)
        {
            return userManager.GetIDUSingEmailAddress(emailAddress);
        }

        public bool UploadImage(USER user, HttpPostedFileBase file)
        {
            byte[] profilePic = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                profilePic = ms.GetBuffer();
            }
            user.PROFILE_PIC = profilePic;
            return userDataAccess.Edit(user);
        }

        public bool EditAboutMe(USER user, string about)
        {
            user.ABOUT_ME = about;
            return userDataAccess.Edit(user);
        }

        public int EditUserAccount(USER user, int ID)
        {
            return userManager.UpdateUserInformation(user,ID);
        }

        public USER GetUserDetailsUsingID(int ID)
        {
            return userManager.GetUserDetailsUsingID(ID);
        }


    }
}
