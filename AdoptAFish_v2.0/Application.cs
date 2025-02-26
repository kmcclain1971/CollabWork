using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptAFish_v2._0
{
    public class Application : IHostedService
    {
        private readonly IHostApplicationLifetime _hostLifetime;
        private readonly ILoggerFactory _logger;

        public Application(IHostApplicationLifetime hostLifetime, ILoggerFactory logger)
        {
            _hostLifetime = hostLifetime;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
