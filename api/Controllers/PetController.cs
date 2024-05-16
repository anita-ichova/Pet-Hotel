using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PetDto;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
        public PetController(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _petRepository.GetAllAsync();
            return Ok(pets);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var pet = await _petRepository.GetByIdAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet.ToPetDto());
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Create([FromRoute] int id, CreatePetDto createPetDto)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null)
            {
                return BadRequest("Pet does not have an owner!");
            }

            var petModel = createPetDto.ToPetFromCreatePetDto(owner.Id);
            owner.Pets.Add(petModel);

            await _petRepository.CreateAsync(petModel);
            
            return Ok(petModel.ToPetDto());
        }

        [HttpPut]
         [Route("{id:int}")]
         public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePetDto updatePet)
         {
            var pet = await _petRepository.GetByIdAsync(id);
            if(pet == null) return NotFound();

           pet.Name = updatePet.Name;
           pet.Species = updatePet.Species;
           pet.Age = updatePet.Age;

            await _petRepository.UpdateAsync(id, updatePet);
            return Ok(updatePet);
         }

         [HttpDelete]
         [Route("{id}")]

         public async Task<IActionResult> Delete([FromRoute] int id)
         {
            var pet = await _petRepository.GetByIdAsync(id);
            if(pet == null) return NotFound();

            await _petRepository.DeleteAsync(id);
             var owner = await _ownerRepository.GetByIdAsync(pet.OwnerId);
            if(owner != null && owner.Pets.Count == 0) 
            {
                await _ownerRepository.DeleteAsync(owner.Id);
            }
            return Ok();
         }
    }
}
