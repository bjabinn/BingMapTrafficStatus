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
            ViewData["Message"] = "Accident map IN LIVE.";

            return View();
        }

        public Response GetTrafficIncidences(string province)
        {
            string bingMapKey = "AnqMOih8bvPT5If6bg0mEKTb-X4liSI8L0snaE4RqecU8X4tqv3Hb5LhQ79YU-4w";
            switch (province){
                case "Sevilla":
                    var trafficResponse = new TrafficRequest()
                    {
                        BingMapsKey = bingMapKey,
                        MapArea = new BoundingBox(new double[] { 37.114344, -6.273244, 37.742494, -5.251515 })
                    };
                    var answerTraffic = ServiceManager.GetResponseAsync(trafficResponse).GetAwaiter().GetResult();
                    return answerTraffic;
                case "Huelva":
                    var trafficResponse2 = new TrafficRequest()
                    {
                        BingMapsKey = bingMapKey,
                        MapArea = new BoundingBox(new double[] { 37.171268, -7.330678, 37.402900, -6.781362 })
                    };
                    var answerTraffic2 = ServiceManager.GetResponseAsync(trafficResponse2).GetAwaiter().GetResult();
                    return answerTraffic2;
                case "Barcelona":
                    var trafficResponse3 = new TrafficRequest()
                    {
                        BingMapsKey = bingMapKey,
                        MapArea = new BoundingBox(new double[] { 41.315417, 2.01316410000004, 41.4469883, 2.2450324999999793 })
                    };
                    var answerTraffic3 = ServiceManager.GetResponseAsync(trafficResponse3).GetAwaiter().GetResult();
                    return answerTraffic3;
                case "Madrid":
                    var trafficResponse4 = new TrafficRequest()
                    {
                        BingMapsKey = bingMapKey,
                        MapArea = new BoundingBox(new double[] { 40.3233352, -3.867697700000008, 40.456804, -3.47533789999 })
                    };
                    var answerTraffic4 = ServiceManager.GetResponseAsync(trafficResponse4).GetAwaiter().GetResult();
                    return answerTraffic4;
            }
            return new Response();

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
