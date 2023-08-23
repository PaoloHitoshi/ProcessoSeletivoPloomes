namespace ProcessoSeletivoPloomesTuneUP.Models
{
    public class PlaylistModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual SongModel Song { get; set; }
    }
}