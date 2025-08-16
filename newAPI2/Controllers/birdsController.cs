using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newAPI2.Models;
using newAPI2.Repository;
using newAPI2.Services;

namespace newAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class birdsController : ControllerBase
    {
        private readonly ibird bird;

        public birdsController(ibird anim)
        {
            bird = anim;
        }

        [HttpGet]
        public async Task<IEnumerable<Bird>> Get()
        {
            return await bird.GetAllBirds();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bird>> get(int id)
        {
            return await bird.GetBirdById(id);
        }
    }
}
