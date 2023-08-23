using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoPloomesTuneUP.Models;

namespace ProcessoSeletivoPloomesTuneUP.Data.Map
{
    public class PlaylistMap : IEntityTypeConfiguration<PlaylistModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PlaylistModel> builder)
        {
            builder.HasAlternateKey(x =>new { x.UserId, x.Id });
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SongId).IsRequired();
            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Song);
        }
    }
}