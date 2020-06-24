using BlueBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBank.WebFrontEnd.Models
{
    public class EmployeeVM
    {
        public Employee employee { get; set; }

        public SelectList Country = new SelectList(countries, "Key", "Value");

        public SelectList States { get; set; }


        #region HomeAddressDropdowns
        private static Dictionary<int, string> countries = new Dictionary<int, string>
        {
            {0, "SELECT A COUNTRY" },
            { 1, "Canada" },
            {2, "USA" }
        };


        private static Dictionary<string, string> usStates = new Dictionary<string, string>
        {
             {"NULL", "SELECT A STATE" },
             { "AL", "Alabama" },
             { "AK", "Alaska" },
             { "AZ", "Arizona" },
             { "AR", "Arkansas" },
             { "CA", "California" },
             { "CO", "Colorado" },
             { "CT", "Connecticut" },
             { "DE", "Delaware" },
             { "DC", "District of Columbia" },
             { "FL", "Florida" },
             { "GA", "Georgia" },
             { "HI", "Hawaii" },
             { "ID", "Idaho" },
             { "IL", "Illinois" },
             { "IN", "Indiana" },
             { "IA", "Iowa" },
             { "KS", "Kansas" },
             { "KY", "Kentucky" },
             { "LA", "Louisiana" },
             { "ME", "Maine" },
             { "MD", "Maryland" },
             { "MA", "Massachusetts" },
             { "MI", "Michigan" },
             { "MN", "Minnesota" },
             { "MS", "Mississippi" },
             { "MO", "Missouri" },
             { "MT", "Montana" },
             { "NE", "Nebraska" },
             { "NV", "Nevada" },
             { "NH", "New Hampshire" },
             { "NJ", "New Jersey" },
             { "NM", "New Mexico" },
             { "NY", "New York" },
             { "NC", "North Carolina" },
             { "ND", "North Dakota" },
             { "OH", "Ohio" },
             { "OK", "Oklahoma" },
             { "OR", "Oregon" },
             { "PA", "Pennsylvania" },
             { "RI", "Rhode Island" },
             { "SC", "South Carolina" },
             { "SD", "South Dakota" },
             { "TN", "Tennessee" },
             { "TX", "Texas" },
             { "UT", "Utah" },
             { "VT", "Vermont" },
             { "VA", "Virginia" },
             { "WA", "Washington" },
             { "WV", "West Virginia" },
             { "WI", "Wisconsin" },
             { "WY", "Wyoming" }
        };

        private static Dictionary<string, string> canadianProvinces = new Dictionary<string, string>
        {
            {"NULL", "SELECT A PROVINCE" },
            {"AB", "Alberta"},
            {"BC", "British Columbia"},
            {"MB", "Manitoba"},
            {"NB", "New Brunswick"} ,
            {"NL", "Newfoundland and Labrador"},
            {"NS", "Nova Scotia"},
            {"NT", "Northwest Territories"},
            {"NU", "Nunavut"},
            {"ON", "Ontario"},
            {"PE", "Prince Edward Island"},
            {"QC", "Québec"},
            {"SK", "Saskatchewan"},
            {"YT", "Yukon"}

        };
        #endregion HomeAddressDropdowns
    }
}