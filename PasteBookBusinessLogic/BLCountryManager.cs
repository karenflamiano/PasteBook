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
        public List<REF_COUNTRY> GetCountry()
        {
            CountryManager countryManager = new CountryManager();
            return countryManager.ListOfCountry();
        }
    }
}
