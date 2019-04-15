using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace NHibernateVsEFcoreQuerys.Models
{
    class SampleContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
                .UseSqlServer(
                   @"Server=(localdb)\mssqllocaldb;Database=HibernateSample;Trusted_Connection=True;ConnectRetryCount=0",
                   p => p.MigrationsHistoryTable("quemDefineOnomeSouEU", "migratons"));
    }
}
