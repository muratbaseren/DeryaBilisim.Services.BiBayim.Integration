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
                ProductId = "f3dee8c4-7185-43fd-82df-009afad1ca16",
                Price = 12500
            });

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
