using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IStayRepository
    {
        public Task<List<Stay>> GetAllStaysAsync();
        public Task<Stay> GetByIdStay (int id);
        public Task CheckInPetAsync(Stay stay);
        public Task UpdateAsync(Stay stay);
        public Task DeleteAsync(int id);
    }
}