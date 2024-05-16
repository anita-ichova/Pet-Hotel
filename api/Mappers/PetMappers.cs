using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PetDto;
using api.Models;

namespace api.Mappers
{
    public static class PetMappers
    {
        public static Pet ToPetFromCreatePetDto(this CreatePetDto petDto, int ownerId)
        {
            return new Pet
            {
                Name = petDto.Name,
                Species = petDto.Species,
                Age = petDto.Age,
                OwnerId = ownerId,
            };
        }

        public static Pet ToPetFromUpdatePetDto(this UpdatePetDto petDto)
        {
            return new Pet
            {
                Name = petDto.Name,
                Species = petDto.Species,
                Age = petDto.Age,
            };
        }

        public static PetDisplayDto ToPetDto(this Pet pet)
        {
            return new PetDisplayDto
            {
                Id = pet.Id,
                Name = pet.Name,
                Species = pet.Species,
                Age = pet.Age,  
            };
        }
    }
}