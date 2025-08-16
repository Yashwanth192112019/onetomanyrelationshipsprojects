using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using newAPI2.Models;
using newAPI2.Repository;
using newAPI2.Services;

namespace newAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class animalController : ControllerBase
    {   
        private readonly ianimal anim;

        public animalController(ianimal anim)
        {
            this.anim = anim;
        }

        [HttpGet]
        public async Task<IEnumerable<Animal>> Get()
        {
            return await anim.GetAllAnimals();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> get(int id)
        {
            return await anim.getbyid(id);
        }

        [HttpPost]
        public async Task<Animal> AddAnimal(Animal animal)
        {
            
            return await anim.AddAnimal(animal);            
        }

        [HttpPut]
        public async Task<Animal> UpdateAnimal(int id, Animal animal)
        {
            return await anim.UpdateAnimal(id, animal);
        }

        [HttpDelete]
        public async Task<Animal> DeleteAnimal(int id)
        {
            return await anim.DeleteAnimal(id);
        } 

    }
}
