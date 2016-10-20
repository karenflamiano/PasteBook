using PasteBookDataAccess.Manager;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class PasswordMatch
    {
        GetUserDetailsUsingEmailAddress account = new GetUserDetailsUsingEmailAddress();
        PasswordManager pwdManager = new PasswordManager();

        public bool PasswordInputAndPasswordFromDBMatch(string email, string password)
        {
            bool result;
            USER user = account.GetAccountEmailAddress(email);
            return result = pwdManager.IsPasswordMatch(password, user.SALT, user.PASSWORD);
        }
    }
}
