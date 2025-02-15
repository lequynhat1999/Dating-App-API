using DatingApp.Entites;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.EntityFramework
{
    public class DatingAppContext: DbContext
    {
        public DatingAppContext(DbContextOptions<DatingAppContext> options) : base(options) { }
        
        public DbSet<AppUser> Users { get; set; }
    }
}
