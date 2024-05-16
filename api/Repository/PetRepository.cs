using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.PetDto;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;
        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Pet pet)
        {
            
            await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pet = await GetByIdAsync(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Pet>> GetAllAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet?> GetByIdAsync(int id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
            return pet == null ? null : pet;
        }

        public async Task UpdateAsync(int id, UpdatePetDto updatePet)
        {
            var existingPet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
            if (existingPet != null)
            {
                existingPet.Name = updatePet.Name;
                existingPet.Species = updatePet.Species;
                existingPet.Age = updatePet.Age;
            }

            await _context.SaveChangesAsync();
        }
    }
}