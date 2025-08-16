using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using relmanytomany.Models;

namespace relmanytomany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cantflyController : ControllerBase
    {
        private readonly context _context;

        public cantflyController(context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<cantfly>> getallbarads()
        {
            return await _context.cantflybirds.Include(e => e.both).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<cantfly>> getbordbyid(int id)
        {
            return await _context.cantflybirds.FirstOrDefaultAsync(e => e.cId == id);
        }

        [HttpPut]
        public async Task<ActionResult<cantfly>> updatebard(int id, cantfly cantfly)
        {
            var res = await _context.cantflybirds.FirstOrDefaultAsync(e => e.cId == id);
            res.cId = cantfly.cId;
            res.age = cantfly.age;
            res.bname = cantfly.bname;
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<cantfly>> addbarad(cantfly cantfly)
        {
            await _context.cantflybirds.AddAsync(cantfly);
            await _context.SaveChangesAsync();
            return cantfly;
        }

        [HttpDelete]
        public async Task<ActionResult<cantfly>> deletebard(int id)
        {
            var res = await _context.cantflybirds.FirstOrDefaultAsync(e => e.cId == id);
            _context.Remove(res);
            await _context.SaveChangesAsync();
            return res;
        }

    }
}
