using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoPloomesTuneUP.Models;

namespace ProcessoSeletivoPloomesTuneUP.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Date_Of_Birth).IsRequired().HasMaxLength(11);
        }
    }
}
