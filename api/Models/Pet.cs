using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public int Age { get; set; }

        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }

        public List<Stay> Stays { get; set; } = new List<Stay>();
    }
}