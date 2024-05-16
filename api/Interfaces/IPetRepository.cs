using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PetDto;
using api.Models;

namespace api.Interfaces
{
    public interface IPetRepository
    {
        public Task<Pet?> GetByIdAsync(int id);
        public Task<List<Pet>> GetAllAsync();
        public Task CreateAsync(Pet pet);
        public Task UpdateAsync(int id, UpdatePetDto updatePet);
        public Task DeleteAsync(int id);
    }
}