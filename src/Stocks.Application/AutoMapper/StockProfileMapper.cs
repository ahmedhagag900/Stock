using AutoMapper;
using Stocks.Application.Models;
using Stocks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.AutoMapper
{
    public class StockProfileMapper:Profile
    {
        public StockProfileMapper()
        {
            CreateMap<Stock, StockIndexModel>()
                .ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StockPrice, opt => opt.MapFrom(src => new StockPriceModel
                {
                    StockPrice = src.StockPrices.OrderByDescending(x => x.ChangeDate).Select(x => x.Price).FirstOrDefault(),
                    StockDate = src.StockPrices.OrderByDescending(x => x.ChangeDate).Select(x => x.ChangeDate).FirstOrDefault()
                }));
            
            CreateMap<Stock, StockDetailModel>()
                .ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StockName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StockPrices, opt => opt.MapFrom(src => src.StockPrices.OrderByDescending(x=>x.ChangeDate).Select(x => new StockPriceModel
                {
                    StockPrice = x.Price,
                    StockDate = x.ChangeDate
                })));
            CreateMap<StockDetailModel, StockModel>()
                .ForMember(dest => dest.StockPrice, opt => opt.MapFrom(src => src.StockPrices.OrderByDescending(o => o.StockDate).Select(x => x.StockPrice).FirstOrDefault()));
        }
    }
}
