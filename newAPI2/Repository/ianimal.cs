using Microsoft.AspNetCore.Mvc;
using newAPI2.Models;

namespace newAPI2.Repository
{
    public interface ianimal
    {
        Task<IEnumerable<Animal>> GetAllAnimals();
        Task<Animal?> getbyid(int id);

        Task<Animal> AddAnimal (Animal animal);

        Task<Animal> UpdateAnimal (int id, Animal animal);

        Task<Animal> DeleteAnimal (int id);
    }
}
