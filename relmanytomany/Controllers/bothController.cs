using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relmanytomany.Models;

namespace relmanytomany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bothController : ControllerBase
    {
        private readonly context _context;

        public bothController(context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<both>> getallbarads()
        {
            return await _context.both.Include(e => e.fly).Include(e => e.cantfly).ToListAsync();
        }
    }
}
