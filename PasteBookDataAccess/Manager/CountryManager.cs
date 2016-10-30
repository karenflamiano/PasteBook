
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

        public List<REF_COUNTRY> ListOfCountry()
        {
            List<REF_COUNTRY> listOfCountries = new List<REF_COUNTRY>();
             
            try
            {
                using (var context = new PASTEBOOKEntities1())
                {
                    foreach (var item in context.REF_COUNTRY.ToList())
                    {
                        listOfCountries.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ListOfException.Add(ex);
            }
            return listOfCountries;
        }

        //public string GetCountryBasedOnID(int? CountryID)
        //{
        //    string Country = "";
        //    try
        //    {
        //        using (var context = new PASTEBOOKEntities1())
        //        {
        //            Country = context.REF_COUNTRY.Where(x => x.ID == CountryID).Select(x => x.COUNTRY).Single();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ListOfException.Add(ex);
        //    }
        //    return Country;
        //}
    }
}
