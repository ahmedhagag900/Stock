using Microsoft.EntityFrameworkCore;
using Stocks.Core.Entities;
using Stocks.Core.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Infrastructure.Data
{
    public class StockDbContextSeed
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly Random _random;
        private readonly StockDbContext _context;
        public StockDbContextSeed(IUnitOfWork unitOfWork,StockDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _random = new Random();
        }
        public async Task SeedAsync()
        {
            _context.Database.Migrate();
            _context.Database.EnsureCreated();

            await SeedStocksAsync();
        }

        private List<Stock> _stockSeedList = new List<Stock>
        {
            new Stock{Name="Walt Disney"},
            new Stock{Name="Uber Technologies"},
            new Stock{Name="LHC Group"},
            new Stock{Name="IAC/InterActiveCorp"},
            new Stock{Name="DXC Technology"},
            new Stock{Name="Alibaba Group"},
            new Stock{Name="Littelfuse"},
            new Stock{Name="Freeport-McMoRan"},
            new Stock{Name="Charles Schwab"},
            new Stock{Name="AmerisourceBergen"},
            new Stock{Name="American Water Works"},
            new Stock{Name="Prologis"},
            new Stock{Name="Bank of America"},
            new Stock{Name="Starbucks"},
            new Stock{Name="T. Rowe Price"},
            new Stock{Name="Crown Castle International"},
            new Stock{Name="Realty Income"},
            new Stock{Name="Chevron"},
            new Stock{Name="EPR Properties"},
            new Stock{Name="Microsoft"},
            new Stock{Name="Google"},
            new Stock{Name="Facebook"},
            new Stock{Name="Careem"},
            new Stock{Name="Amazon"}
        };
        
        private async Task SeedStocksAsync()
        {
            var hasData = await _unitOfWork.StockRepo.GetByAsync(x => true);
            if(!hasData.Any())
            {
                foreach (var stock in _stockSeedList)
                {
                    StockPrice stockPriceSeed = new StockPrice
                    {
                        Price = _random.Next(20, 500),
                        ChangeDate = DateTime.UtcNow
                    };
                    stock.Code = Guid.NewGuid().ToString();
                    stock.StockPrices.Add(stockPriceSeed);
                    await _unitOfWork.StockRepo.AddAsync(stock);
                }
                await _unitOfWork.CompleteAsync();
            }
        }


    }
}
