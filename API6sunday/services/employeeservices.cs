using API6sunday.Models;
using API6sunday.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API6sunday.services
{
    public class employeeservices : Iemployee
    {
        private readonly context _context;

        public employeeservices(context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<employee>> getallemployee()
        {
            return await _context.emps.Include(e => e.both).ToListAsync();
        }

        public async Task<ActionResult<employee>> getemployeebyId(int id)
        {
            return await _context.emps.Include(e => e.both).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ActionResult<employee>> addemployee(employee employee)
        {
            await _context.emps.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<ActionResult<employee>> updateemployee(int id, employee employee)
        {
            var res = await _context.emps.FindAsync(id);
            res.Id = employee.Id;
            res.Name = employee.Name;
            res.Description = employee.Description;
            return res;
        }

        public async Task<ActionResult<employee>> deleteemployee(int id)
        {
            var res = await _context.emps.FindAsync(id);
            _context.Remove(res);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
