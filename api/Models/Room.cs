using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quality { get; set; } 
        public int Capacity { get; set; } 

        public List<Stay> Stays { get; set; } = new List<Stay>();
    }
}