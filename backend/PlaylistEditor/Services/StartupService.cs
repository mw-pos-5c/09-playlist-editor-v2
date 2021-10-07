using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

namespace PlaylistEditor.Services
{
    public class StartupService : IHostedService
    {

        private readonly DataProviderService dataProviderService;

        public StartupService(DataProviderService dataProviderService)
        {
            this.dataProviderService = dataProviderService;
        }

 
        private void LoadData()
        {
            ParseCsvFile("playlist.csv");
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(LoadData, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
