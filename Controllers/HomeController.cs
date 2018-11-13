using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BingMapCore2_1.Models;
using BingMapsRESTToolkit;

namespace BingMapCore2_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public Response GetTrafficIncidences(string province)
        {
            var trafficResponse = new TrafficRequest()
            {
                BingMapsKey = "AnqMOih8bvPT5If6bg0mEKTb-X4liSI8L0snaE4RqecU8X4tqv3Hb5LhQ79YU-4w",
                MapArea = new BoundingBox(new double[] { 36.2790, -7.431179, 38.560447, -3.86 })
            };
            var answerTraffic = ServiceManager.GetResponseAsync(trafficResponse).GetAwaiter().GetResult();
            return answerTraffic;
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
