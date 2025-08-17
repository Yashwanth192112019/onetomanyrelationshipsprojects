using API6sunday.Models;
using Microsoft.AspNetCore.Mvc;

namespace API6sunday.Repository
{
    public interface Idepartment
    {
        public Task<IEnumerable<department>> getalldepts();

        public Task<ActionResult<department>> getdeptbyId(int id);

        public Task<ActionResult<department>> adddept(department department);

        public Task<ActionResult<department>> updatedept(int id, department department);

        public Task<ActionResult<department>> deletedept(int id);
    }
}
