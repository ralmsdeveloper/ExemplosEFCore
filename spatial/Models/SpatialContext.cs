using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpatialDemo.Logging;

namespace SpatialDemo.Models
{
    class SpatialContext : DbContext
    {
        public static readonly LoggerFactory _loggerFactory = new LoggerFactory(new[] { new SqlLoggerProvider() });

        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
                .UseSqlServer(
                   @"Server=(localdb)\mssqllocaldb;Database=SpatialSample;Trusted_Connection=True;ConnectRetryCount=0",
                    x => x.UseNetTopologySuite())
                .UseLoggerFactory(_loggerFactory); 
    }
}
