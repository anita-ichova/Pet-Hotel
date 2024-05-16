using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IRoomRepository
    {
        public Task<Room?> GetByIdAsync(int id);
        public Task<List<Room>> GetAllAsync();
        public Task UpdateAsync(Room room);
    }
}