using System.Drawing.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using newAPI2.Models;
using newAPI2.Repository;
using NuGet.Protocol;

namespace newAPI2.Services
{
    public class animalservice : ianimal
    {
        private readonly context _context;
        public animalservice(context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Animal>> GetAllAnimals()
        {
            return await _context.animals.Include(e => e.Birds).ToListAsync();
        }


        async Task<Animal?> ianimal.getbyid(int id)
        {
            return await _context.animals.Include(e => e.Birds).FirstOrDefaultAsync(e => e.AnimalId == id);
        }

        public async Task<Animal> AddAnimal(Animal animal)
        {
            await _context.animals.AddAsync(animal);
            await _context.SaveChangesAsync();
            return animal;
        }


        public async Task<Animal?> UpdateAnimal(int id, Animal animal)
        {
            var existing = await _context.animals.FindAsync(id);
            if (existing == null) return null;

            existing.AnimalId = animal.AnimalId;
            existing.Description = animal.Description;
            existing.Habitat = animal.Habitat;
            existing.SpeciesName = animal.SpeciesName;

            await _context.SaveChangesAsync();
            return existing;
        }


        public async Task<Animal> DeleteAnimal(int id)
        {
            var c = await _context.animals.FindAsync(id);
            _context.animals.Remove(c);
            await _context.SaveChangesAsync();
            return c;
        } 
    
    }
}
