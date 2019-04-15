using System;
using System.Linq;
using Functions.Models;
using Microsoft.EntityFrameworkCore;

namespace Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new SampleContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                _ = db.Eventos.Select(p => Funcoes.SqlLeft(p, 10)).ToList();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
