using Microsoft.EntityFrameworkCore;
using Service.Types;
using DotNetEnv;

namespace Service.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Follower> Followers { get; set; }

        public MyDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Load enviornment variables.
            Env.Load();

            // Configure database.
            optionsBuilder.UseSqlite(Environment.GetEnvironmentVariable("ConnectionString"));
        }
    }
}