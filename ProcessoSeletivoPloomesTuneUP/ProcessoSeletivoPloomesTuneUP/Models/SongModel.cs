namespace ProcessoSeletivoPloomesTuneUP.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Genre { get; set; }
        public DateTime Release_Date { get; set; }
        public string BandName { get; set; }
    }
}
