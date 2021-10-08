using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

using PlaylistEditor.Models;
using PlaylistEditor.Services;

namespace PlaylistEditor.Controllers
{
    [ApiController]
    [Route("/api")]
    public class PlaylistController : ControllerBase
    {
        private readonly DataProviderService dataProvider;

        public PlaylistController(DataProviderService dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        [HttpGet]
        [Route("playlists")]
        public IActionResult GetPlaylists()
        {
            return Ok(dataProvider.Playlists);
        }
        
        [HttpGet]
        [Route("playlisttracks/{id}")]
        public IActionResult GetPlaylists(int id)
        {
            IEnumerable<Track> tracks = dataProvider.Tracks.Where(track =>
            {
                return dataProvider.PlaylistTracks.FindIndex(playlistTrack => playlistTrack.PlaylistId == id && playlistTrack.TrackId == track.Id) != -1;
            });
            
            return Ok(tracks);
        }

        [HttpGet]
        [Route("genres")]
        public IActionResult GetGenres()
        {
            return Ok(dataProvider.Genres);
        }
        
        [HttpGet]
        [Route("tracks")]
        public IActionResult GetTracks(int genreid)
        {
            return Ok(dataProvider.Tracks.Where(track => track.GenreId == genreid));
        }

        [HttpPost]
        [Route("track")]
        public IActionResult AddPlaylistTrack([FromBody] PlaylistTrack track)
        {
            dataProvider.PlaylistTracks.Add(track);
            return Ok();
        }

        [HttpDelete]
        [Route("track")]
        public IActionResult RemoveTrack(int playlistid, int trackid)
        {
            int index = dataProvider.PlaylistTracks.FindIndex(track => track.PlaylistId == playlistid && track.TrackId == trackid);
            if (index == -1) return BadRequest();
            dataProvider.PlaylistTracks.RemoveAt(index);
            return Ok(index);
        }
    }
}
