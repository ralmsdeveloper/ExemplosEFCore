using Microsoft.EntityFrameworkCore;

namespace Transactions.Models
{
    class SampleContext1 : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
                .UseSqlServer(
                   @"Server=(localdb)\mssqllocaldb;Database=TransactionsSample1;Trusted_Connection=True;ConnectRetryCount=0"); 
    }

    class SampleContext2 : DbContext
    {
        public DbSet<Festa> Festas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
                .UseSqlServer(
                   @"Server=(localdb)\mssqllocaldb;Database=TransactionsSample2;Trusted_Connection=True;ConnectRetryCount=0");
    }
}
