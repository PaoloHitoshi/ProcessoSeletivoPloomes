using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoPloomesTuneUP.Data;
using ProcessoSeletivoPloomesTuneUP.Models;
using ProcessoSeletivoPloomesTuneUP.Repository.Interfaces;

namespace ProcessoSeletivoPloomesTuneUP.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly TuneUPDBContext _dbContext;

        public SongRepository(TuneUPDBContext tuneUPDBContext)
        {
            _dbContext = tuneUPDBContext;
        }

        public async Task<List<SongModel>> GetAllSongs()
        {
            return await _dbContext.Songs.ToListAsync();
        }

        public async Task<SongModel> GetSongById(int id)
        {
            return await _dbContext.Songs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SongModel> PostSong(SongModel song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();

            return song;
        }

        public async Task<SongModel> PutSong(SongModel song, int id)
        {
            SongModel updateSong = await GetSongById(id);

            if (updateSong == null)
            {
                throw new Exception($"User ID: {id} not found on database.");
            }

            updateSong.Name = song.Name;
            updateSong.Genre = song.Genre;
            updateSong.Release_Date = song.Release_Date;
            updateSong.BandName = song.BandName;

            _dbContext.Songs.Update(updateSong);
            await _dbContext.SaveChangesAsync();

            return updateSong;
        }

        public async Task<bool> DeleteSong(int id)
        {
            SongModel removeSong = await GetSongById(id);

            if (removeSong == null)
            {
                throw new Exception($"User ID: {id} not found on database.");
            }

            _dbContext.Songs.Remove(removeSong);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<SongModel>> GetSongByGenre(string genre)
        {
            var query = "SELECT * FROM Songs WHERE Genre = @genre";

            var parameter = new SqlParameter("@genre", genre);

            var listOfSongs = _dbContext.Songs.FromSqlRaw(query, parameter).ToList<SongModel>();

            return listOfSongs;
        }

        public async Task<List<SongModel>> GetSongByBandName(string bandName)
        {
            var query = "SELECT * FROM Songs WHERE BandName = @bandName";

            var parameter = new SqlParameter("@bandName", bandName);

            var listOfSongs = _dbContext.Songs.FromSqlRaw(query, parameter).ToList<SongModel>();

            return listOfSongs;
        }
    }
}
