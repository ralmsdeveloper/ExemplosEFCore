using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Transactions.Models;

namespace Transactions
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SampleContext1())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

            } 

            using (var transaction = new TransactionScope())
            {
                using (var db = new SampleContext1())
                {
                    db.Eventos.Add(new Evento
                    {
                        Cidade = "Sao Paulo",
                        Nome = "MVPCOnf"
                    });

                    db.SaveChanges();

                    transaction.Complete();
                } 
            }

            Console.WriteLine("Hello World!");
        }
    }
}
