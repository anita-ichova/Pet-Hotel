using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.OwnerDto;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
           
            return Ok(owner.ToOwnerDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var owners = await _ownerRepository.GetAllAsync();
            return Ok(owners);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOwnerDto ownerDto)
        {
            var owner = new Owner
            {
                Name = ownerDto.Name,
                Email = ownerDto.Email,
                Phone = ownerDto.Phone,
            };

            await _ownerRepository.CreateAsync(owner);
            return Ok(owner);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOwnerDto updateOwner)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            
            owner.Name = updateOwner.Name;
            owner.Email = updateOwner.Email;
            owner.Phone = updateOwner.Phone;
            
            await _ownerRepository.UpdateAsync(id, owner);

            return Ok(updateOwner);
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            await _ownerRepository.DeleteAsync(id);
            return Ok(owner);
        }
    }
}