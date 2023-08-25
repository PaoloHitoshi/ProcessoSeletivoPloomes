using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoPloomesTuneUP.Data;
using ProcessoSeletivoPloomesTuneUP.Models;
using ProcessoSeletivoPloomesTuneUP.Repository.Interfaces;

namespace ProcessoSeletivoPloomesTuneUP.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly TuneUPDBContext _dbContext;

        public PlaylistRepository(TuneUPDBContext tuneUPDBContext)
        {
            _dbContext = tuneUPDBContext;
        }

        public async Task<bool> DeleteSongOnPlaylist(int playlistId, int songId)
        {
            var query = "DELETE FROM Playlist WHERE Id = @playlistId AND SongId = @songId";

            var parameter = new SqlParameter("@playlistId", playlistId);

            var secondParameter = new SqlParameter("@songId", songId);

             _dbContext.Database.ExecuteSqlRaw(query, parameter, secondParameter);
            
            return true;
        }

        public async Task<List<PlaylistModel>> GetPlaylistSongsById(int id)
        {
            var query = "SELECT * FROM Playlist WHERE Id = @id";

            var parameter = new SqlParameter("@id", id);

            var listOfSongs = _dbContext.Playlist.FromSqlRaw(query, parameter).ToList<PlaylistModel>();

            return listOfSongs;
        }

        public async Task<PlaylistModel> PostSongOnPlaylist(PlaylistModel newSongOnPlaylist)
        {
            await _dbContext.Playlist.AddAsync(newSongOnPlaylist);
            await _dbContext.SaveChangesAsync();

            return newSongOnPlaylist;
        }
    }
}
