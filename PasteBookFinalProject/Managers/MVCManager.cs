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
            dataAccess.AddUser(MVCMapper.MapMVCModelToDAEntities(user));
            return 0;
        }

        public List<CountryModel> GetCountry()
        {
            //List<CountryModel> listOfRoutes = new List<CountryModel>();
            //return listOfRoutes;
            return dataAccess.GetCountry();
            //return 0;
        }


    }
}