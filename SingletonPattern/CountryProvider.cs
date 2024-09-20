using SingletonPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class CountryProvider
    {
        private static CountryProvider instance = null;
        public static CountryProvider Instance => instance ?? (instance = new CountryProvider());
        private new List<Country> Countries { get; set; }

        private CountryProvider()
        {
            // retrieving data from db
            Task.Delay(2000).GetAwaiter().GetResult();

            Countries = new List<Country>()
            {
                new Country(){Name = "Turkey"},
                new Country(){Name = "Belgium"},
            };
        }

        public int CountryCount => Countries.Count;

        public async Task<List<Country>> GetCountries() => Countries;
    }
}
