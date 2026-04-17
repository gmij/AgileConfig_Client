using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgileConfig.Client
{
    class ClientShutdownHostService : IHostedService
    {
        private readonly IConfigClient _configClient;

        public ClientShutdownHostService(IConfigClient configClient)
        {
            _configClient = configClient;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                // close websocket
                await _configClient?.DisconnectAsync();
            }
            catch
            {
            }
        }
    }
}
