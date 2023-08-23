using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoPloomesTuneUP.Models;

namespace ProcessoSeletivoPloomesTuneUP.Data.Map
{
    public class SongMap : IEntityTypeConfiguration<SongModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SongModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Genre).HasMaxLength(150);
            builder.Property(x => x.Release_Date).IsRequired().HasMaxLength(11);
            builder.Property(x => x.BandName).IsRequired().HasMaxLength(255);
        }
    }
}
