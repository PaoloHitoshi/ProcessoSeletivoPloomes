using Microsoft.EntityFrameworkCore;
using ProcessoSeletivoPloomesTuneUP.Data.Map;
using ProcessoSeletivoPloomesTuneUP.Models;

namespace ProcessoSeletivoPloomesTuneUP.Data
{
    public class TuneUPDBContext : DbContext
    {
        public TuneUPDBContext(DbContextOptions<TuneUPDBContext> options) : base(options)
        { 
        }

        public DbSet<UserModel> Users { get; set; } 
        public DbSet<SongModel> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new SongMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
