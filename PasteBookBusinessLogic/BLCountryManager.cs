using PasteBookDataAccess.Manager;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookBusinessLogic
{
    public class BLCountryManager
    {
        CountryManager countryManager = new CountryManager();
        public List<REF_COUNTRY> GetCountry()
        {
            return countryManager.ListOfCountry();
        }

        //public string GetCountryName(int? CountryID)
        //{
        //    return countryManager.GetCountryBasedOnID(CountryID);
        //}
    }
}
