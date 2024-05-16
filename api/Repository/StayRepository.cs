using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class StayRepository : IStayRepository
    {
        private readonly ApplicationDbContext _context;
        public StayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task CheckInPetAsync(Stay stay)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Stay>> GetAllStaysAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Stay> GetByIdStay(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Stay stay)
        {
            throw new NotImplementedException();
        }
    }
}