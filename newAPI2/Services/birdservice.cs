using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using newAPI2.Models;
using newAPI2.Repository;

namespace newAPI2.Services
{
    public class birdservice : ibird
    {
        private readonly context _context;

        public birdservice(context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bird>> GetAllBirds()
        {
            return await _context.birds.Include(e => e.Animal).ToListAsync();
        }

        async Task<Bird> ibird.GetBirdById(int id)
        {
            return await _context.birds.FirstOrDefaultAsync(e => e.BirdId == id);
        }

    }
}
