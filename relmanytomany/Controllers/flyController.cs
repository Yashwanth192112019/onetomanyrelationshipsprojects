using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using relmanytomany.Models;

namespace relmanytomany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class flyController : ControllerBase
    {
        private readonly context _context;

        public flyController(context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<fly>> GetAllflies()
        {
            return await _context.birds.Include(e => e.both).ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<fly>> GetById(int id)
        {
            return await _context.birds.FirstOrDefaultAsync(e => e.bId == id);
        }

        [HttpPut]
        public async Task<ActionResult<fly>> updatebird(int id, fly fly)
        {
            var res = await _context.birds.FirstOrDefaultAsync(e => e.bId == id);
            res.bId = fly.bId;
            res.age = fly.age;
            res.cname = fly.cname;
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<fly>> addbird(fly fly)
        {
            await _context.birds.AddAsync(fly);
            await _context.SaveChangesAsync();
            return fly;
        }

        [HttpDelete]
        public async Task<ActionResult<fly>> deletebird(int id)
        {
            var res = await _context.birds.FindAsync(id);
            _context.birds.Remove(res);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
