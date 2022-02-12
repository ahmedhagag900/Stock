using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stocks.Core.UOW;
using Stocks.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Web.Middlewares
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TransactionMiddleware> _logger;
        public TransactionMiddleware(RequestDelegate next,ILogger<TransactionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
                
        }

        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork, StockDbContext dbContext)
        {

            try
            {
                var stratgy = dbContext.Database.CreateExecutionStrategy();
                await stratgy.ExecuteAsync(async () =>
                {
                    _logger.LogInformation("Transaction Begins");
                    await dbContext.BeginTransactionAsync();
                    await _next(context);
                    await unitOfWork.CompleteAsync();
                    await dbContext.CommitTransactionAsync();
                    _logger.LogInformation("Transaction commited");
                });
            }catch(Exception)
            {
                _logger.LogInformation("Transaction failed rolling back");
                await dbContext.RollBackTransactionAsync();
                _logger.LogInformation("Transaction rolled back");
                throw;
            }

        }
    }
}
