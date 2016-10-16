using PasteBookDataAccess.Entities;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Mappers
{
    public static class Mapper
    {
        public static USER MapUserEntityToDBUserTable(User userEntity)
        {
            USER tblUser = new USER()
            {
                ID = userEntity.ID,
                USER_NAME = userEntity.USER_NAME,
                PASSWORD = userEntity.PASSWORD,
                SALT = userEntity.SALT,
                FIRST_NAME = userEntity.FIRST_NAME,
                LAST_NAME = userEntity.LAST_NAME,
                BIRTHDAY = userEntity.BIRTHDAY,
                COUNTRY_ID = userEntity.COUNTRY_ID,
                MOBILE_NO = userEntity.MOBILE_NO,
                GENDER = userEntity.GENDER.ToString(),
                PROFILE_PIC = userEntity.PROFILE_PIC,
                DATE_CREATED = userEntity.DATE_CREATED,
                ABOUT_ME = userEntity.ABOUT_ME,
                EMAIL_ADDRESS = userEntity.EMAIL_ADDRESS
            };

            return tblUser;
        }
        
        public static User MapDBUserTableToUserEntity(USER userTable)
        {
            User userEntity = new User()
            {
                ID = userTable.ID,
                USER_NAME = userTable.USER_NAME,
                PASSWORD = userTable.PASSWORD,
                SALT = userTable.SALT,
                FIRST_NAME = userTable.FIRST_NAME,
                LAST_NAME = userTable.LAST_NAME,
                BIRTHDAY = userTable.BIRTHDAY,
                COUNTRY_ID = (int)userTable.COUNTRY_ID,
                MOBILE_NO = userTable.MOBILE_NO,
                GENDER = userTable.GENDER[0],
                PROFILE_PIC = userTable.PROFILE_PIC,
                DATE_CREATED = userTable.DATE_CREATED,
                ABOUT_ME = userTable.ABOUT_ME,
                EMAIL_ADDRESS = userTable.EMAIL_ADDRESS
            };

            return userEntity;
        }

        public static REF_COUNTRY MapCountryEntityToDBCountryTable(Country countryEntity)
        {
            REF_COUNTRY tblCountry = new REF_COUNTRY()
            {
                ID = countryEntity.ID,
                COUNTRY = countryEntity.COUNTRY
            };
            return tblCountry;
        }

        public static Country MapDBCountryTableToCountryEntity(REF_COUNTRY countryTable)
        {
            Country countryEntity = new Country()
            {
                ID = countryTable.ID,
                COUNTRY = countryTable.COUNTRY
            };
            return countryEntity;
        }
    }
}
