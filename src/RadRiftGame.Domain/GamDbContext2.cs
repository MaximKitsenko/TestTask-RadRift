using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RadRiftGame.Domain.Services.Db;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RadRiftGame.Domain
{
    public partial class GamDbContext2 : DbContext
    {
        public GamDbContext2()
        {
        }

        public GamDbContext2(DbContextOptions<GamDbContext2> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=127.0.0.1; database=GameDB;Trusted_Connection=False;User Id=sa;Password=yourStrong(!)Password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
        
        public DbSet<GameResult> GamesResults { get; set; }
    }
}
