using PasteBookFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PasteBookDataAccess;
using PasteBookFinalProject;

namespace PasteBookFinalProject.Managers
{
    public class MVCManager
    {
        DataAccess dataAccess = new DataAccess();

        public int AddUser(UserModel user)
        {
            dataAccess.AddUser(MVCMapper.MapMVCUserModelToDAUserEntities(user));
            return 0;
        }

        public UserModel GetUserDetails(string emailAddress)
        {
            return MVCMapper.MapDAUserEntitiesToMVCUserModel(dataAccess.GetUserDetails(emailAddress)); 
        }


        public List<CountryModel> GetCountry()
        {
            List<CountryModel> listOfCountries = new List<CountryModel>();
            foreach (var item in dataAccess.GetCountry())
            {
                listOfCountries.Add(MVCMapper.MapCountryDAEntitesToMVCCountryModel(item));
            }
            return listOfCountries;
        }

        public bool CheckUsername(string username)
        {
            bool checkUsername;
            checkUsername = dataAccess.CheckIfUsernameExists(username);
            return checkUsername;
        }

        public bool CheckEmailAddress(string emailAddress)
        {
            bool checkUsername;
            checkUsername = dataAccess.CheckIfEmailAddressExists(emailAddress);
            return checkUsername;
        }

        public bool CheckUserCredentials(LoginViewModel userLogin)
        {
            if (userLogin != null)
            {
                if (dataAccess.CheckIfEmailAddressExists(userLogin.LoginModel.LoginEmail))
                {
                    bool result = dataAccess.PasswordInputAndPasswordFromDBMatch(userLogin.LoginModel.LoginEmail, userLogin.LoginModel.LoginPassword);
                    return result;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public int GetUserIDUsingEmail(string emailAdress)
        {
            return dataAccess.GetUserDetailsUsingEmail(emailAdress);
        }

        public List<PostModel> GetPosts()
        {
            List<PostModel> listOfPosts = new List<PostModel>();
            foreach (var item in dataAccess.GetPosts())
            {
                listOfPosts.Add(MVCMapper.(item));
            }
            return listOfCountries;
        }


    }
}