using PasteBookDataAccess.Entities;
using PasteBookDataAccess.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PasteBookDataAccess.Manager.PasswordManager;

namespace PasteBookDataAccess
{
    public class DataAccess
    {
        UserManager manager = new UserManager();
        PasswordManager pwdManager = new PasswordManager();

        public void AddUser(User user)
        {
            //gawan ng password hash, and salt
            user.SALT = SaltGenerator.GetSaltString();
            var stringPassword = user.PASSWORD;
            user.PASSWORD = pwdManager.GetPasswordHash(stringPassword + user.SALT);
            manager.AddUsertoDB(user);
        }

        public List<Country> GetCountry()
        {
            CountryManager countryManager = new CountryManager();
            return countryManager.ListOfCountry();
        }

        public bool CheckIfUsernameExists(string username)
        {
            bool returnValue;
            returnValue = manager.CheckIfUsernameExists(username);
            return returnValue;
        }

        public bool CheckIfEmailAddressExists(string emailAddress)
        {
            bool returnValue;
            returnValue = manager.CheckIfEmailExists(emailAddress);
            return returnValue;
        }
    }
}
