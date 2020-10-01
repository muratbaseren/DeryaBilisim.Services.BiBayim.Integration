using DeryaBilisim.BiBayim.Integration.Standart;
using DeryaBilisim.BiBayim.SampleCompanyWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DeryaBilisim.BiBayim.SampleCompanyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BiBayimService _biBayimService;

        public HomeController(ILogger<HomeController> logger, BiBayimService biBayimService)
        {
            _logger = logger;
            _biBayimService = biBayimService;
        }

        public IActionResult Index()
        {
            var response = _biBayimService.AddCommissionToDealer(new CommissionApiModel
            {
                ReferalCode = "B0P0RL89",
                Price = 15000
            });

            if (response.Data != null && response.Data.success)
            {
                ViewBag.Result = response.Data.success ? "success" : "error occured";
            }
            else
            {
                if (response.Data == null)
                    ViewBag.Result = "no response";
                else
                    ViewBag.Result = string.Join(" - ", response.Data.errors);
            }


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
