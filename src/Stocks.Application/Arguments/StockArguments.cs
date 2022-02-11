using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.Arguments
{
    public class StockArgument
    {
        public long StockId { get; set; }
        public string StockName { get; set; }
        public double StockPrice { get; set; }
    }
}
