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

        public static POST MapPostEntityToDBPostTable(Post postEntity)
        {
            POST tblPost = new POST()
            {
                ID = postEntity.ID,
                CREATED_DATE = postEntity.CREATED_DATE,
                CONTENT = postEntity.CONTENT,
                PROFILE_OWNER_ID = postEntity.PROFILE_OWNER_ID,
                POSTER_ID = postEntity.POSTER_ID
            };
            return tblPost;
        }

        public static Post MapDBPostTableToPostEntity(POST postTable)
        {
            Post postEntity = new Post()
            {
                ID = postTable.ID,
                CREATED_DATE = postTable.CREATED_DATE,
                CONTENT = postTable.CONTENT,
                PROFILE_OWNER_ID = (int)postTable.PROFILE_OWNER_ID,
                POSTER_ID = (int)postTable.POSTER_ID
            };
            return postEntity;
        }

        public static FRIEND MapFriendEntityToFriendDB(Friend friendEntity)
        {
            FRIEND tblFriend = new FRIEND()
            {
                ID = friendEntity.ID,
                FRIEND_ID = friendEntity.FRIEND_ID,
                USER_ID = friendEntity.USER_ID,
                REQUEST = friendEntity.REQUEST.ToString(),
                BLOCKED = friendEntity.BLOCKED.ToString(),
                CREATED_DATE = friendEntity.CREATED_DATE
            };
            return tblFriend;
        }

        public static Friend MapFriendDBToFriendEntity(FRIEND friendTable)
        {
            Friend friendEntity = new Friend()
            {
                ID = friendTable.ID,
                FRIEND_ID = friendTable.FRIEND_ID,
                USER_ID = friendTable.USER_ID,
                REQUEST = Convert.ToChar(friendTable.REQUEST),
                BLOCKED = Convert.ToChar(friendTable.BLOCKED),
                CREATED_DATE = friendTable.CREATED_DATE 
            };
            return friendEntity;
        }

        public static List<User> MapUserListFromDB(List<USER> user)
        {
            List<User> userList = new List<User>();
            foreach (var item in user)
            {
                userList.Add(new User()
                {
                    ID = item.ID,
                    ABOUT_ME = item.ABOUT_ME,
                    BIRTHDAY = item.BIRTHDAY,
                    DATE_CREATED = item.DATE_CREATED,
                    EMAIL_ADDRESS = item.EMAIL_ADDRESS,
                    FIRST_NAME = item.FIRST_NAME,
                    GENDER = Convert.ToChar(item.GENDER),
                    LAST_NAME = item.LAST_NAME,
                    MOBILE_NO = item.MOBILE_NO,
                    PASSWORD = item.PASSWORD,
                    PROFILE_PIC = item.PROFILE_PIC,
                    SALT = item.SALT,
                    USER_NAME = item.USER_NAME
                });
            }

            return userList;
        }

        public static List<Post> MapRetrievePostFromDB(List<POST> post)
        {
            List<Post> entityPost = new List<Post>();
            foreach (var item in post)
            {
                entityPost.Add(new Post()
                {
                    ID = item.ID,
                    POSTER_ID = item.POSTER_ID,
                    CONTENT = item.CONTENT,
                    CREATED_DATE = item.CREATED_DATE,
                    PROFILE_OWNER_ID = item.PROFILE_OWNER_ID
                });
            }
            return entityPost;
        }

    }
}
