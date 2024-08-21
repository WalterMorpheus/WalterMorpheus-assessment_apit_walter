using Microsoft.EntityFrameworkCore;
using Repo.Data.Models;

namespace Repo.Data
{
    /*The Code shared across the Capturing Details and Displaying Details*/
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {
            /*This will create a database if it dose not exist*/
            Database.EnsureCreated();
        }

        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<Location> Location { get; set; }
    }
}
