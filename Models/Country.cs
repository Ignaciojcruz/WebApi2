using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.DAL;

namespace WebApi2.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public List<Country> Get_Country()
        {
            CountryDAL countryDAL = new CountryDAL();
            return countryDAL.Get_Country(this);
        }

        public Country Get_Country(int id)
        {
            CountryDAL countryDAL = new CountryDAL();
            return countryDAL.Get_Country(id);
        }

        public int Set_Country(Country country)
        {
            CountryDAL countryDAL = new CountryDAL();
            return countryDAL.Set_Country(country);
        }

        public int Delete_Country(int id)
        {
            CountryDAL countryDAL = new CountryDAL();
            return countryDAL.Delete_Country(id);
        }
    }
}