using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stocks.Application.Interfaces;
using Stocks.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStockService _stockService;

        public HomeController(ILogger<HomeController> logger,IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        public async Task<IActionResult> Index()
        {
            var stocks = await _stockService.GetAllStocksAsync();
            return View(stocks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
