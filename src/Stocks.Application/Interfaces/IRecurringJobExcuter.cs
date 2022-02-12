using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stocks.Application.Interfaces
{
    public interface IRecurringJobExcuter
    {
        /// <summary>
        /// excuete recurring job
        /// </summary>
        /// <param name="cancellationToken">cancelation token to abort the job</param>
        /// <returns></returns>
        Task ExceuteAsync(CancellationToken cancellationToken);
    }
}
