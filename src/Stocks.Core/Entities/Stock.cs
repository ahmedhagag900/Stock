using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.Entities
{
    public class Stock
    {
        public Stock()
        {
            StockPrices = new HashSet<StockPrice>();
        }
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<StockPrice> StockPrices { get; set; }

    }
}
