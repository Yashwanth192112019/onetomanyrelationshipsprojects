using newAPI2.Models;

namespace newAPI2.Repository
{
    public interface ibird
    {
        Task<IEnumerable<Bird>> GetAllBirds();

        Task<Bird?> GetBirdById(int id);
    }
}
