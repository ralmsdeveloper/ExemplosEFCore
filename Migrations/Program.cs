using System;
using Microsoft.EntityFrameworkCore;
using Migrations.Models;

namespace Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SampleContext())
            {

                // Script do banco de dados
                string sqlDatabase = db.Database.GenerateCreateScript();

                // Migrações pendentes
                var pendents = db.Database.GetPendingMigrations();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
