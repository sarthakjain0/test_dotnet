using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using test_dotnet.Models;

namespace test_dotnet.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }
        public ActionResult Create()
        {
            var countries = GetCountries();
            ViewBag.Countries = new SelectList(countries, "Name", "Name");
            ViewBag.States = new SelectList(Enumerable.Empty<string>());

            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {

            return View("Details", user);
        }
        public ActionResult GetStates(string countryName)
        {
            var states = GetStatesByCountry(countryName);
            return Json(states, JsonRequestBehavior.AllowGet);
        }
        private List<Country> GetCountries()
        {
            var countries = new List<Country>
            {
                new Country
                {
                    Name = "United States",
                    States = new List<string>
                    {
                        "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida",
                        "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine",
                        "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska",
                        "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio",
                        "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas",
                        "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"
                    }
                },
                new Country
                {
                    Name = "Canada",
                    States = new List<string>
                    {
                        "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland and Labrador", "Northwest Territories",
                        "Nova Scotia", "Nunavut", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon"
                    }
                },
                new Country
                {
                    Name = "United Kingdom",
                    States = new List<string>
                    {
                        "England", "Scotland", "Wales", "Northern Ireland"
                    }
                }
            };

            return countries;
        }
        private List<string> GetStatesByCountry(string countryName)
        {
            var countries = GetCountries();
            var country = countries.FirstOrDefault(c => c.Name == countryName);
            if (country != null)
            {
                return country.States;
            }

            return new List<string>();
        }
    }
}
