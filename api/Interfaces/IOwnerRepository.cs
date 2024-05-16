using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.OwnerDto;
using api.Models;

namespace api.Interfaces
{
    public interface IOwnerRepository
    {
        public Task<Owner?> GetByIdAsync(int id);
        public Task<List<Owner>> GetAllAsync();
        public Task CreateAsync(Owner owner);
        public Task UpdateAsync(int id, Owner owner);
        public Task DeleteAsync(int id);
    }
}