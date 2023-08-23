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
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _songRepository;

        public SongController(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SongModel>>> GetAllSongs()
        {
            List<SongModel> Songs = await _songRepository.GetAllSongs();
            return Ok(Songs);
        }

        [HttpPost]
        public async Task<ActionResult<SongModel>> PostSong([FromBody] SongModel newSong)
        {
            SongModel Song = await _songRepository.PostSong(newSong);

            return Ok(Song);
        }

        [HttpGet("{genre}/genreSongs")]
        public async Task<ActionResult<List<SongModel>>> GetSongByGenre(string genre)
        {
            List<SongModel> genreSongs = await _songRepository.GetSongByGenre(genre);
            return Ok(genreSongs);
        }

        [HttpGet("{bandName}/bandSongs")]
        public async Task<ActionResult<List<SongModel>>> GetSongByBandName(string bandName)
        {
            List<SongModel> bandSongs = await _songRepository.GetSongByBandName(bandName);
            return Ok(bandSongs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SongModel>> GetSongById(int id)
        {
            SongModel Song = await _songRepository.GetSongById(id);
            return Ok(Song);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SongModel>> PutSong([FromBody] SongModel updateSong, int id)
        {
            updateSong.Id = id;
            SongModel Song = await _songRepository.PutSong(updateSong, id);
            return Ok(Song);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SongModel>> DeleteSong(int id)
        {
            bool isDeleted = await _songRepository.DeleteSong(id);
            return Ok(isDeleted);
        }
    }
}
