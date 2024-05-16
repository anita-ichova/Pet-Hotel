using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.OwnerDto;
using api.Models;

namespace api.Mappers
{
    public static class OwnerMapper
    {
        public static OwnerDto ToOwnerDto(this Owner owner)
        {
            return new OwnerDto
            {
                Id = owner.Id,
                Name = owner.Name,
                Email = owner.Email,
                Phone = owner.Phone,
                Pets = owner.Pets.Select(p => p.ToPetDto()).ToList(),
            };
        }
    }
}