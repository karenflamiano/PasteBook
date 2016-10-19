using PasteBookDataAccess.Entities;
using PasteBookDataAccess.Mappers;
using PasteBookEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasteBookDataAccess.Manager
{
   public class CountryManager
    {
        List<Exception> ListOfException = new List<Exception>();

        public List<Country> ListOfCountry()
        {
            List<Country> listOfCountries = new List<Country>();
             
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    foreach (var item in context.REF_COUNTRY.ToList())
                    {
                        listOfCountries.Add(Mapper.MapDBCountryTableToCountryEntity(item));
                    }
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }

            return listOfCountries;

        }
    }
}
