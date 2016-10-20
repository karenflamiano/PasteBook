using PasteBookFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using PasteBookDataAccess;
using PasteBookFinalProject;
using PasteBookBusinessLogic;
using PasteBookEntityFramework;

namespace PasteBookFinalProject.Managers
{
    public class MVCManager
    {
        //GetCountryList getCountry = new GetCountryList();
        //PasteBookBusinessLogic dataAccess = new PasteBookBusinessLogic();

        UserManager userManager = new UserManager();
        GetListOfCountry getCountry = new GetListOfCountry();
        PostManager postManager = new PostManager();
        PasswordMatch passwordMatch = new PasswordMatch();
        
        public int AddUser(USER user)
        {
            userManager.AddUserAccount(user);
            return 0;
        }

        public USER GetUserDetails(string emailAddress)
        {
            return userManager.GetAccountDetailsUsingEmail(emailAddress);
        }

        public int GetUserID(string emailAddress)
        {
            //return dataAccess.GetIDUsingEmailAddress(emailAddress);
            return userManager.GetAccountIDUsingEmail(emailAddress);
        }


        public List<REF_COUNTRY> GetCountry()
        {
            List<REF_COUNTRY> listOfCountries = new List<REF_COUNTRY>();
            foreach (var item in getCountry.GetCountry())
            {
                listOfCountries.Add(item);
            }
            return listOfCountries;
        }

        public bool CheckUsername(string username)
        {
            bool checkUsername = false;
            //checkUsername = dataAccess.CheckIfUsernameExists(username);               //ni-comment out ni erbs
            return checkUsername;
        }

        public bool CheckEmailAddress(string emailAddress)
        {
            bool checkUsername;
            checkUsername = userManager.CheckIfEmailAddressExists(emailAddress);
            return checkUsername;
        }

        public bool CheckUserCredentials(LoginViewModel userLogin)
        {
            if (userLogin != null)
            {
                if (userManager.CheckIfEmailAddressExists(userLogin.LoginModel.LoginEmail))
                {
                    bool result = passwordMatch.PasswordInputAndPasswordFromDBMatch(userLogin.LoginModel.LoginEmail, userLogin.LoginModel.LoginPassword);
                    return result;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


        public List<POST> GetPosts(int ID)
        {
            List<POST> listOfPosts = new List<POST>();
            foreach (var item in postManager.NewsFeedPosts(ID))
            {
                listOfPosts.Add(item);
            }
            return listOfPosts;
        }

        public int AddPost(POST post)
        {
            postManager.AddPost(post);
            return 0;
        }


    }
}