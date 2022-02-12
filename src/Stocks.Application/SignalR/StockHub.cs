using Microsoft.AspNetCore.SignalR;
using Stocks.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.SignalR
{
    public class StockHub : Hub<IStockHub>
    {

    }
}
