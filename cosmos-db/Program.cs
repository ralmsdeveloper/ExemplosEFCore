// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                // Recreate database

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Add some data...
                context.Eventos.AddRange(
                    new Evento
                    {
                        Id = 1,
                        Name = "MVPCONF LATAM",
                        Url = "http:/mvpconf.com.br",
                        Palestrantes = new List<Palestrante>
                       {
                           new Palestrante
                           {
                               Id = 1,
                               EventoId = 1,
                               Blog = "ralms.net",
                               Name = "RAFAEL ALMEIDA"

                           }
                       }
                    }); 

                var affected = context.SaveChanges();

                Console.WriteLine($"Persistidos -> {affected}");
                Console.ReadLine();
            }

            using (var context = new BloggingContext())
            {
                var evento = context.Eventos.Single(b => b.Name == "MVPCONF LATAM");
                Console.WriteLine($"{evento.Name} - {evento.Url}");

                foreach (var palestrante in context.Palestrantes.Where(p => p.EventoId == evento.Id))
                {
                    Console.WriteLine($" - {palestrante.Name}");
                }

                Console.ReadLine();
            }
        }
    }

    public class BloggingContext : DbContext
    {
        private static readonly ILoggerFactory loggerFactory = new LoggerFactory()
            .AddConsole((s, l) => l == LogLevel.Debug && s.EndsWith("Command"));

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Evento>()
                 .Metadata
                 .Cosmos().ContainerName = "Eventos";

            modelBuilder
                 .Entity<Palestrante>()
                 .Metadata
                 .Cosmos().ContainerName = "Palestrantes";

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseCosmos(
                    "https://localhost:8081",
                    "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                    "MVPCONF2019")
                .UseLoggerFactory(loggerFactory);
        }

    }

    public class Evento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Palestrante> Palestrantes { get; set; }
    }

    public class Palestrante
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public string Name { get; set; }
        public string Blog { get; set; }
    }
}
