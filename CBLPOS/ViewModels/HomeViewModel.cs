using System;
using System.Collections.Generic;
using CBLPOS.Models;

namespace CBLPOS.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            CountryList = new List<Country>();
            CountryList.Add(new Country() { Name = "Country1", IsSelected = false, IsVisible = true });
            CountryList.Add(new Country() { Name = "Country2", IsSelected = false, IsVisible = true });
            CountryList.Add(new Country() { Name = "Country3", IsSelected = false, IsVisible = true });
            CountryList.Add(new Country() { Name = "Country4", IsSelected = false, IsVisible = true });
            CountryList.Add(new Country() { Name = "Country5", IsSelected = false, IsVisible = true });
            CountryList.Add(new Country() { Name = "Country6", IsSelected = false, IsVisible = true });
        }

        public List<Country> CountryList { get; set; }
       
    }
   
}
