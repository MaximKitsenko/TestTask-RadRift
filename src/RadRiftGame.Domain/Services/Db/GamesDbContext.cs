using Microsoft.EntityFrameworkCore;

namespace RadRiftGame.Domain.Services.Db
{
    public class GamesDbContext : DbContext  
    {  
        public GamesDbContext(DbContextOptions options) : base(options)  
        {  
        }  
  
        public DbSet<GameResult> GameResults { get; set; }  
    }
}