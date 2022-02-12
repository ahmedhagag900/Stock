using AutoMapper;
using Stocks.Application.Arguments;
using Stocks.Application.Exceptions;
using Stocks.Application.Interfaces;
using Stocks.Application.Models;
using Stocks.Core.Entities;
using Stocks.Core.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Random _random;
        public StockService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _random = new Random();
        }
        public async Task<StockIndexModel> AddStockAsync(StockArgument args)
        {
            //prepare stock info
            var stockPrice = new StockPrice
            {
                ChangeDate = DateTime.UtcNow,
                Price = args.StockPrice
            };
            var stockEntity = new Stock
            {
                Code = Guid.NewGuid().ToString(),
                Name = args.StockName
            };
            stockEntity.StockPrices.Add(stockPrice);

            //add it to uow
            stockEntity =await _unitOfWork.StockRepo.AddAsync(stockEntity);

            //return result after compelation of uow
            var result = _mapper.Map<StockIndexModel>(stockEntity);
            return result;
        }
        public async Task DeleteStockAsync(long stockId)
        {
            var entityToDelete = await _unitOfWork.StockRepo.GetByIdAsync(stockId);
            if (entityToDelete == null)
                throw new StockAppException("could not found stock with specified id to delete");
            await _unitOfWork.StockRepo.Delete(entityToDelete);
        }
        public async Task<IEnumerable<StockIndexModel>> GetAllStocksAsync()
        {
            var entities = await _unitOfWork.StockRepo.GetByAsync(x => true);

            var result = entities.Select(x => _mapper.Map<StockIndexModel>(x)) 
                                 .OrderByDescending(x => x.StockPrice?.StockPrice).ToList();

            return result;
        }
        public async Task<StockDetailModel> GetStockInfoAsync(long stockId)
        {
            var entity = await  _unitOfWork.StockRepo.GetByIdAsync(stockId);

            if (entity == null)
                throw new StockAppException("could not found stock with specified id");

            var result = _mapper.Map<StockDetailModel>(entity);

            return result;
        }
        public async Task<IEnumerable<StockIndexModel>> PerformRandomStockPriceUpdates()
        {
            var randomSample = await _unitOfWork.StockRepo.GetRandomStocksAsync(10);
            foreach(var stock in randomSample)
            {
                var randomPrice = new StockPrice
                {
                    ChangeDate = DateTime.UtcNow,
                    Price = _random.Next(50, 500)
                };
                stock.StockPrices.Add(randomPrice);
            }
            await _unitOfWork.CompleteAsync();

            var finalResult = await GetAllStocksAsync();
            return finalResult;
        }
        public async Task<StockIndexModel> UpdateStockInfoAsync(StockArgument args)
        {

            var entity = await _unitOfWork.StockRepo.GetByIdAsync(args.StockId);
            if (entity == null)
                throw new StockAppException("could not found stock with specified id to update");

            entity.Name = args.StockName;
            entity.StockPrices.Add(new StockPrice
            {
                Price = args.StockPrice,
                ChangeDate = DateTime.UtcNow
            });

            var result = _mapper.Map<StockIndexModel>(entity);
            return result;

        }
    }
}
