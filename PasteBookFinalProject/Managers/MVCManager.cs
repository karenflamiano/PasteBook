using PasteBookFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PasteBookDataAccess;
using PasteBookFinalProject.Mappers;

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

        //public bool CheckUserCredentials(UserCredentialModel user)
        //{
        //    if (user != null)
        //    {
        //        var currentUser = manager.Login(user.EmailAddress);
        //        if (currentUser != null)
        //        {
        //            bool result = pManager.IsPasswordMatch(user.Password, currentUser.Salt, currentUser.PasswordHash);
        //            return result;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return false;
        //}
    }
}