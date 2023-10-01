using AgaroAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgaroAPI.Data
{
    public class AgaroDbContext : DbContext
    {
        public AgaroDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { 

        }

        public DbSet<LocationMaster> LocationMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
    }
}
