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
    public class UserManager
    {
        GetUser getUser = new GetUser();
        PasswordManager pwdManager = new PasswordManager();
        //GeneratePostManager postManager = new GeneratePostManager();
        GetUserDetailsUsingEmailAddress getEmailAddress = new GetUserDetailsUsingEmailAddress();
        GetUserIDUsingEmailAddress getUserID = new GetUserIDUsingEmailAddress();


        //PasteBookDataAccess<USER> dataAccess = new PasteBookDataAccess<USER>();
        public void AddUserAccount(USER user)
        {
            user.SALT = SaltGenerator.GetSaltString();
            var stringPassword = user.PASSWORD;
            user.PASSWORD = pwdManager.GetPasswordHash(stringPassword + user.SALT);
            getUser.AddUsertoDB(user);
            //dataAccess.Create(user);
        }
        
        public bool CheckIfUsernameExists(string username)
        {
            bool returnValue;
            //returnValue = dataAccess.GetOneResult(username);
            returnValue = getUser.CheckIfUsernameExists(username);
            return returnValue;
        }

        public bool CheckIfEmailAddressExists(string emailAddress)
        {
            bool returnValue;
            returnValue = getUser.CheckIfEmailExists(emailAddress);
            return returnValue;
        }


        public USER GetAccountDetailsUsingEmail(string email)
        {
            return getEmailAddress.GetAccountEmailAddress(email);
        }

        public int GetAccountIDUsingEmail(string emailAddress)
        {
            return getUserID.GetAccountEmailAddress(emailAddress);
        }

    }

}
