using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Functions.Models
{
    class SampleContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDbFunction(typeof(Funcoes)
                .GetMethod(nameof(Funcoes.SqlLeft)))
                .HasTranslation(args =>
                {
                    var argumentos = args.ToList();
                    return new SqlFunctionExpression(
                        "LEFT",
                        typeof(string),
                        argumentos);
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options
                .UseSqlServer(
                   @"Server=(localdb)\mssqllocaldb;Database=Functions;Trusted_Connection=True;ConnectRetryCount=0");
    }

    public class Funcoes
    {
        public static string SqlLeft(object obj, int length)
          =>  string.Empty;
    }
}
