using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.Models
{
    public class StockIndexModel
    {
        public long StockId { get; set; }
        public bool StockState { get; set; } = true;
        public string StockName { get; set; }
        public StockPriceModel StockPrice { get; set; }
    }
}
