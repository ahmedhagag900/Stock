using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stocks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Infrastructure.Data.EntityConfigurations
{
    public class StockPriceTypeConfiguration : IEntityTypeConfiguration<StockPrice>
    {
        public void Configure(EntityTypeBuilder<StockPrice> builder)
        {
            builder.HasKey(x => new { x.StockId ,x.Price, x.ChangeDate});
        }
    }
}
