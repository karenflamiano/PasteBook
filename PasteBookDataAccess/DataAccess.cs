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
        GetUserAccountManager account = new GetUserAccountManager();
        GetUserDetailsUsingEmailAddress getDetails = new GetUserDetailsUsingEmailAddress();
        GeneratePostManager postManager = new GeneratePostManager();

        public void AddUser(User user)
        {
            user.SALT = SaltGenerator.GetSaltString();
            var stringPassword = user.PASSWORD;
            user.PASSWORD = pwdManager.GetPasswordHash(stringPassword + user.SALT);
            manager.AddUsertoDB(user);
        }

        public User GetUserDetails(string email)
        {
            return account.GetAccountEmailAddress(email);
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

        public bool PasswordInputAndPasswordFromDBMatch(string email, string password)
        {
            bool result;
            User user2 = account.GetAccountEmailAddress(email);
            return result = pwdManager.IsPasswordMatch(password, user2.SALT, user2.PASSWORD);
        }

        public int GetUserDetailsUsingEmail(string email)
        {
            return getDetails.GetAccountEmailAddress(email);
        }

        public void AddPost(Post post)
        {
            postManager.AddPostToDB(post);
        }

        public List<Post> GetPosts()
        {
            GetAllPostsManager getAllPosts = new GetAllPostsManager();
            return getAllPosts.ListOfPosts();
        }
    }
}
