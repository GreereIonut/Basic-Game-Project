using Microsoft.EntityFrameworkCore;
namespace Games.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
    }
}