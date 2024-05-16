using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.PetDto
{
    public class UpdatePetDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
         [Required]
        public string Species { get; set; } = string.Empty;
         [Required]
        public int Age { get; set; }

    }
}