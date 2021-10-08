using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using PlaylistEditor.Models;
using PlaylistEditor.Utils;

namespace PlaylistEditor.Services
{
    public class StartupService : IHostedService
    {

        private readonly DataProviderService dataProviderService;
        private readonly ILogger<StartupService> logger;

        public StartupService(DataProviderService dataProviderService, ILogger<StartupService> logger)
        {
            this.dataProviderService = dataProviderService;
            this.logger = logger;
        }

 
        private void LoadData()
        {
            logger.Log(LogLevel.Information, "Parsing csv files ...");
            try
            {
                dataProviderService.Playlists = CsvParser.ParseCsvFile<Playlist>("playlist.csv", Playlist.ParseCsvLine);
                dataProviderService.Genres = CsvParser.ParseCsvFile<Genre>("genre.csv", Genre.ParseCsvLine);
                dataProviderService.Tracks = CsvParser.ParseCsvFile<Track>("track.csv", Track.ParseCsvLine);
                dataProviderService.PlaylistTracks = CsvParser.ParseCsvFile<PlaylistTrack>("playlist-track.csv", PlaylistTrack.ParseCsvLine);

                dataProviderService.Tracks.Sort((track, track1) => String.Compare(track.Name, track1.Name, StringComparison.Ordinal)
                );
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.ToString());
                return;
            }
            logger.Log(LogLevel.Debug, $"Parsed playlists: {dataProviderService.Playlists.Count}");
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
