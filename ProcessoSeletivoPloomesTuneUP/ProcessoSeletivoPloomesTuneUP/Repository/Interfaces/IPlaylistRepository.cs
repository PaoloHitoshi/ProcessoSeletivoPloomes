using ProcessoSeletivoPloomesTuneUP.Models;

namespace ProcessoSeletivoPloomesTuneUP.Repository.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<List<PlaylistModel>> GetPlaylistSongsById(int id);
        Task<PlaylistModel> PostSongOnPlaylist(PlaylistModel newSongOnPlaylist);
        Task<bool> DeleteSongOnPlaylist(int playlistId, int songId);
    }
}
