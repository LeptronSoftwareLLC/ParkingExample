using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyParkingAPI.Models
{
    public class Location
    {
        public Location() { }
        public Location(int locationID, string description, int count, int maxSpaces)
        {
            LocationID = locationID;
            Description = description;
            Count = count;
            MaxSpaces = maxSpaces;
        }
        private int _locationID;
        private string _description;
        private int _count;
        private int _max;

        public int LocationID { get => _locationID; set => _locationID = value; }
        public string Description { get => _description; set => _description = value; }
        public int Count { get => _count; set => _count = value; }
        public int MaxSpaces { get => _max; set => _max = value; }
    }
}
