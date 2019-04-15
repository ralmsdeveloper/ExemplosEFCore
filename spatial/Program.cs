using System;
using System.Linq;
using NetTopologySuite.Geometries;
using SpatialDemo.Models;

namespace SpatialDemo
{
    class Program
    {
        static void Main()
        {
            using (var db = new SpatialContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.AddRange(
                  new Location { Coordinates = new Point(0, 0) { SRID = 4326 }, City = "Sao Paulo" },
                  new Location { Coordinates = new Point(1, 1) { SRID = 4326 }, City = "Aracaju" });
                db.SaveChanges();


                var aracajuLocation = new Point(1, 1) { SRID = 4326 };
                var nearestMesurements =
                  from m in db.Locations
                  where m.Coordinates.Distance(aracajuLocation) < 2
                  select m;

                foreach (var m in nearestMesurements)
                {
                    Console.WriteLine(m.City);
                }
            }

            Console.WriteLine(); 
            Console.ReadKey(intercept: true);
        }
    }
}
