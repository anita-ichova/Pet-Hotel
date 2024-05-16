using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Stay
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PetId { get; set; }
        public Pet? Pet { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }
    }
}