using API6sunday.Models;
using Microsoft.AspNetCore.Mvc;

namespace API6sunday.Repository
{
    public interface Iemployee
    {
        public Task<IEnumerable<employee>> getallemployee();

        public Task<ActionResult<employee>> getemployeebyId(int id);

        public Task<ActionResult<employee>> addemployee(employee employee);

        public Task<ActionResult<employee>> updateemployee(int id, employee employee);

        public Task<ActionResult<employee>> deleteemployee(int id);
    }
}
