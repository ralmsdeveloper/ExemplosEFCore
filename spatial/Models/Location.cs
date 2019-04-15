using NetTopologySuite.Geometries;

namespace SpatialDemo.Models
{
    public class Location
    {
        public int Id { get; set; }
        public Point Coordinates { get; set; }
        public string City { get; set; }
    }
}
