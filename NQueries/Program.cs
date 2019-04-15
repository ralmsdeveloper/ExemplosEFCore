// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NQueries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new SampleContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Cities
                    .AddRange(
                        new City { Name = "Seattle", Country = "USA" },
                        new City { Name = "Redmond", Country = "USA" },
                        new City { Name = "Itabaiana", Country = "BRA" }
                    );

                context.People.AddRange(
                    new Person
                    {
                        FirstName = "Diego",
                        LastName = "Vega",
                        City = "Redmond"
                    },
                    new Person
                    {
                        FirstName = "Rafael",
                        LastName = "Almeida",
                        City = "Aracaju"
                    },
                    new Person
                    {
                        FirstName = "Smit",
                        LastName = "Patel",
                        City = "Redmond"
                    });

                context.SaveChanges();
            }

            using (var db = new SampleContext())
            {
                var cities = db
                    .Cities
                    .Where(c => c.Country == "BRA")
                    .ToList();

                var peoples = db.People
                    .Where(p => cities.Select(p => p.Name).Contains(p.City))
                    .Select(p => new
                    {
                        p,
                        Fullname = p.FirstName + " " + p.LastName
                    });


                _ = peoples.ToList();
            }
        }
    }

    public class SampleContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=_ModelApp;Trusted_Connection=True;Connect Timeout=5;ConnectRetryCount=0");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasKey(e => new { e.Name, e.Country });
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
    } 
}
