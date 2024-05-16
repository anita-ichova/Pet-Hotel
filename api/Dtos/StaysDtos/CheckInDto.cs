using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.StaysDtos
{
    public class CheckInDto
    {
        public int PetId { get; set; }
        public int RoomId { get; set; }
    }
}