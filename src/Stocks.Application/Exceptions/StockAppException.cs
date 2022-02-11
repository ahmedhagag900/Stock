using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.Exceptions
{
    public class StockAppException:Exception
    {
        public StockAppException(string message):base(message)
        {
                
        }
        public StockAppException(string message,Exception innerException) : base(message,innerException)
        {

        }
    }
}
