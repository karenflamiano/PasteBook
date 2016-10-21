using PasteBookDataAccess;
using PasteBookDataAccess.Manager;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class BLUserManager
    {
        UserManager userManager = new UserManager();
        PasswordManager pwdManager = new PasswordManager();
      

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


        public USER GetAccountDetailsUsingEmail(string email)
        {
            return userManager.GetAccountEmailAddress(email);
        }

        public int GetAccountIDUsingEmail(string emailAddress)
        {
            return userManager.GetIDUSingEmailAddress(emailAddress);
        }

    }

}
