using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Core.Entities
{
    public class StockPrice
    {
        public long StockId { get; set; }
        public DateTime ChangeDate { get; set; }
        public double Price { get; set; }
    }
}
