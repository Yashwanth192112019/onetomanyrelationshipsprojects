using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API5experiment.Models;

namespace API5experiment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class enrollmentsController : ControllerBase
    {
        private readonly context _context;

        public enrollmentsController(context context)
        {
            _context = context;
        }

        // GET: api/enrollments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<enrollment>>> Getenrollment()
        {
            return await _context.enrollment.Include( e => e.teacher).Include(e => e.student).ToListAsync();
        }
    }
}
