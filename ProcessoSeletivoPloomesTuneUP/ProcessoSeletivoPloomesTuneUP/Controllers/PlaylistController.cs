using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivoPloomesTuneUP.Models;
using ProcessoSeletivoPloomesTuneUP.Repository.Interfaces;
using System.Data;
using System.Net;

namespace ProcessoSeletivoPloomesTuneUP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistController(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PlaylistModel>>> GetPlaylistSongsById(int id)
        {
            List<PlaylistModel> playlistSongs = await _playlistRepository.GetPlaylistSongsById(id);
            return Ok(playlistSongs);
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistModel>> PostSongOnPlaylist([FromBody] PlaylistModel newSongOnPlaylist)
        {
            PlaylistModel newSong = await _playlistRepository.PostSongOnPlaylist(newSongOnPlaylist);

            return Ok(newSong);
        }

        [HttpDelete]
        public async Task<ActionResult<PlaylistModel>> DeleteSongOnPlaylist(int playlistId, int songId)
        {
            bool isDeleted = await _playlistRepository.DeleteSongOnPlaylist(playlistId, songId);
            return Ok(isDeleted);
        }
    }
}
