using Microsoft.EntityFrameworkCore;
using Ralms.EntityFrameworkCore.Tests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HintsSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();

            using (var db = new SampleContext())
            {
                db
                   .Blogs
                   .WithHint(SqlServerHints.NOLOCK)
                   .ToList();
            }

            Console.WriteLine("Hello World!");
        }



        private static void SetupDatabase()
        {
            using (var db = new SampleContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                for (int i = 0; i < 10; i++)
                {
                    db.Blogs.Add(new Blog
                    {
                        Name = $"Teste {i}",
                        Date = DateTime.Now,
                        Posts = new[]
                        {
                        new Post
                        {
                            Content = $"Test Content {i}",
                            Title = $"Title Post {i}"
                        }
                    }
                    });
                }
                 
                db.SaveChanges();
            } 
        }

    }



}
