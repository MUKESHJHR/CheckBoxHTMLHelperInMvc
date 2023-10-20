using CheckBoxHTMLHelperInMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace CheckBoxHTMLHelperInMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<City> CityList = new List<City>()
            {
                new City(){ CityId = 1, CityName = "London", IsSelected = false },
                new City(){ CityId = 2, CityName = "New York", IsSelected = false },
                new City(){ CityId = 3, CityName = "Sydney", IsSelected = true },
                new City(){ CityId = 4, CityName = "Mumbai", IsSelected = false },
                new City(){ CityId = 5, CityName = "Cambridge", IsSelected = false },
                new City(){ CityId = 6, CityName = "Delhi", IsSelected = false },
                new City(){ CityId = 7, CityName = "Hyderabad", IsSelected = true }
            };

            return View(CityList);
        }

        [HttpPost]
        public string Index(IEnumerable<City> cities)
        {
            if (cities.Count(x => x.IsSelected) == 0)
            {
                return "You have not selected any City";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You Selected - ");
                foreach (City city in cities)
                {
                    if (city.IsSelected)
                    {
                        sb.Append(city.CityName + ", ");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                return sb.ToString();
                {

                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}