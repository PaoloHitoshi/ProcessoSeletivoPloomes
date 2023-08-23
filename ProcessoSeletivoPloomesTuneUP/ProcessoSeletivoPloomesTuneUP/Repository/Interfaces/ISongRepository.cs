using ProcessoSeletivoPloomesTuneUP.Models;

namespace ProcessoSeletivoPloomesTuneUP.Repository.Interfaces
{
    public interface ISongRepository
    {
        Task<List<SongModel>> GetAllSongs();
        Task<SongModel> GetSongById(int id);
        Task<List<SongModel>> GetSongByGenre (string genre);
        Task<List<SongModel>> GetSongByBandName (string bandName);
        Task<SongModel> PostSong(SongModel song);
        Task<SongModel> PutSong(SongModel song, int id);
        Task<bool> DeleteSong(int id);
    }
}
