using PasteBookDataAccess.Entities;
using PasteBookFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasteBookFinalProject.Mappers
{
    public static class MVCMapper
    {
        public static UserModel MapDAUserEntitiesToMVCUserModel(User userEntity)
        {
            UserModel userModel = new UserModel()
            {
                Username = userEntity.USER_NAME,
                Password = userEntity.PASSWORD,
                FirstName = userEntity.FIRST_NAME,
                LastName = userEntity.LAST_NAME,
                Birthday = userEntity.BIRTHDAY,
                CountryID = userEntity.COUNTRY_ID,
                MobileNumber = userEntity.MOBILE_NO,
                Gender = userEntity.GENDER,
                AboutMe = userEntity.ABOUT_ME,
                //ProfilePicture = userEntity.PROFILE_PIC,
                EmailAddress = userEntity.EMAIL_ADDRESS
            };
            return userModel;
        }
        

        public static User MapMVCUserModelToDAUserEntities( UserModel userModel)
        {
            User userEntity = new User()
            {
                USER_NAME = userModel.Username,
                PASSWORD = userModel.Password,
                FIRST_NAME = userModel.FirstName,
                LAST_NAME = userModel.LastName,
                BIRTHDAY = userModel.Birthday,
                COUNTRY_ID = userModel.CountryID,
                MOBILE_NO = userModel.MobileNumber,
                GENDER = userModel.Gender,
                ABOUT_ME = userModel.AboutMe,
                //PROFILE_PIC = userModel.ProfilePicture,
                EMAIL_ADDRESS = userModel.EmailAddress
            };
            return userEntity;
        }

        public static CountryModel MapCountryDAEntitesToMVCCountryModel(Country countryEntity)
        {
            CountryModel countryModel = new CountryModel()
            {
                CountryID = countryEntity.ID,
                CountryName = countryEntity.COUNTRY
            };

            return countryModel;
        }

        public static Country MapMVCCountryModelToDACountryEntites(CountryModel countryModel)
        {
            Country countryEntity = new Country()
            {
                ID = countryModel.CountryID,
                COUNTRY = countryModel.CountryName
            };
            return countryEntity;
        }


    }
}