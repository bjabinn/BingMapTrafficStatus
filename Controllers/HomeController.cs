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
        
            switch (province){
                case "Sevilla":
                    var trafficResponse = new TrafficRequest()
                    {
                        BingMapsKey = "AnqMOih8bvPT5If6bg0mEKTb-X4liSI8L0snaE4RqecU8X4tqv3Hb5LhQ79YU-4w",
                        MapArea = new BoundingBox(new double[] { 37.114344, -6.273244, 37.742494, -5.251515 })
                    };
                    var answerTraffic = ServiceManager.GetResponseAsync(trafficResponse).GetAwaiter().GetResult();
                    return answerTraffic;
                case "Huelva":
                    var trafficResponse2 = new TrafficRequest()
                    {
                        BingMapsKey = "AnqMOih8bvPT5If6bg0mEKTb-X4liSI8L0snaE4RqecU8X4tqv3Hb5LhQ79YU-4w",
                        MapArea = new BoundingBox(new double[] { 37.171268, -7.330678, 37.402900, -6.781362 })
                    };
                    var answerTraffic2 = ServiceManager.GetResponseAsync(trafficResponse2).GetAwaiter().GetResult();
                    return answerTraffic2;
                case "Malaga":
                    var trafficResponse3 = new TrafficRequest()
                    {
                        BingMapsKey = "AnqMOih8bvPT5If6bg0mEKTb-X4liSI8L0snaE4RqecU8X4tqv3Hb5LhQ79YU-4w",
                        MapArea = new BoundingBox(new double[] { 36.650458, -4.550710, 36.763769, -4.359933 })
                    };
                    var answerTraffic3 = ServiceManager.GetResponseAsync(trafficResponse3).GetAwaiter().GetResult();
                    return answerTraffic3;
                case "Madrid":
                    var trafficResponse4 = new TrafficRequest()
                    {
                        BingMapsKey = "AnqMOih8bvPT5If6bg0mEKTb-X4liSI8L0snaE4RqecU8X4tqv3Hb5LhQ79YU-4w",
                        MapArea = new BoundingBox(new double[] { 36.650458, -4.550710, 36.844127, -4.289785 })
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
