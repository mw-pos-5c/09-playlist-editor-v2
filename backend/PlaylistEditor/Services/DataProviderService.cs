using System.Collections.Generic;

using PlaylistEditor.Models;

namespace PlaylistEditor.Services
{
    public class DataProviderService
    {

        public List<Playlist> Playlists { get; set; }
        public List<Genre> Genres { get; set; }
        public List<PlaylistTrack> PlaylistTracks { get; set; }
        public List<Track> Tracks { get; set; }
        
        
    }
}
