using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace PlaylistEditor.Controllers
{
    [ApiController]
    [Route("/api")]
    public class PlaylistController : ControllerBase
    {

        [HttpGet]
        [Route("playlists")]
        public IActionResult GetPlaylists()
        {
            return null;
        }

    }
}
