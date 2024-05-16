using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.OwnerDto;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _context;
        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var owner = await GetByIdAsync(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                _context.SaveChanges();
            }

        }

        public async Task<List<Owner>> GetAllAsync()
        {
           return await _context.Owners.ToListAsync();
        }

        public async Task<Owner?> GetByIdAsync(int id)
        {
           var owner = await _context.Owners.Include(o => o.Pets).FirstOrDefaultAsync(i => i.Id == id);

           return owner == null ? null : owner;
        }

        public async Task UpdateAsync(int id, Owner updateOwner)
        {
            var existingOwner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
            if (existingOwner != null)
            {
                existingOwner.Name = updateOwner.Name;
                existingOwner.Email = updateOwner.Email;    
                existingOwner.Phone = updateOwner.Phone;
                existingOwner.Pets = updateOwner.Pets;
            }

           await _context.SaveChangesAsync();
        }
    }
}