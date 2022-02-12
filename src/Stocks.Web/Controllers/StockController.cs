using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stocks.Application.Arguments;
using Stocks.Application.Interfaces;
using Stocks.Application.Models;
using Stocks.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Web.Controllers
{
    [Route("[controller]")]
    [Route("/")]
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StockController(IStockService stockService,IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("stocks")]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _stockService.GetAllStocksAsync();
            return Json(stocks);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Details(long stockId)
        {
            var stockInfo = await _stockService.GetStockInfoAsync(stockId);
            return View(stockInfo);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Edit(long stockId)
        {
            var stockInfo = await _stockService.GetStockInfoAsync(stockId);
            var result = _mapper.Map<StockModel>(stockInfo);
            return View(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Edit(StockModel model)
        {
            if(ModelState.IsValid)
            {
                var res = await _stockService.UpdateStockInfoAsync(new StockArgument
                {
                    StockId = model.StockId,
                    StockName = model.StockName,
                    StockPrice = model.StockPrice
                });
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Route("[action]")]
        public async Task<IActionResult> Delete(long stockId)
        {
            await _stockService.DeleteStockAsync(stockId);
            return RedirectToAction(nameof(Index));
        }
        
        [Route("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(StockModel model)
        {
            if(ModelState.IsValid)
            {
                var res = await _stockService.AddStockAsync(new StockArgument
                {
                    StockName = model.StockName,
                    StockPrice = model.StockPrice
                });
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        [Route("[action]")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
