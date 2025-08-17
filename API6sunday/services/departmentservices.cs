using API6sunday.Models;
using API6sunday.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API6sunday.services
{
    public class departmentservices : Idepartment
    {
        private readonly context _context;

        public departmentservices(context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<department>> getalldepts()
        {
            return await _context.depts.Include(e => e.both).ToListAsync();
        }

        public async Task<ActionResult<department>> getdeptbyId(int id)
        {
            return await _context.depts.Include(e => e.both).FirstOrDefaultAsync(e => e.DId == id);
        }

        public async Task<ActionResult<department>> adddept(department department)
        {
            await _context.depts.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<ActionResult<department>> updatedept(int id, department department)
        {
            var res = await _context.depts.FindAsync(id);
            res.DId = department.DId;
            res.Description = department.Description;
            res.Dname = department.Dname;
            return res;
        }

        public async Task<ActionResult<department>> deletedept(int id)
        {
            var res = await _context.depts.FindAsync(id);
            _context.Remove(res);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
