using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ralms.EntityFrameworkCore.Tests
{
    public class SampleContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WithNoLock;Trusted_Connection=True;ConnectRetryCount=0")
                .RalmsExtendFunctions()
                .UseLoggerFactory(_loggerFactory)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelo)
        {
            modelo.EnableSqlServerDateDIFF();
        }

        private static readonly ILoggerFactory _loggerFactory = new LoggerFactory()
            .AddDebug()
            .AddConsole((s, l) => l == LogLevel.Information && !s.EndsWith("Connection"));
    }
}
