using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.Models
{
    public class StockDetailModel
    {
        public long StockId { get; set; }
        public string StockName { get; set; }
        public IEnumerable<StockPriceModel> StockPrices { get; set; }
    }
}
