using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS_SYSTEM.Data;
using LMS_SYSTEM.Models;
using LMS_SYSTEM.Class;

namespace LMS_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class student_to_workController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public student_to_workController(ApplicationDbContextApp context)
        {
            _context = context;
        }

        // GET: api/student_to_work
        [HttpGet]
        public async Task<ActionResult<IEnumerable<student_to_work>>> Getstudent_to_work()
        {
          if (_context.student_to_work == null)
          {
              return NotFound();
          }
            return await _context.student_to_work.ToListAsync();
        }

        // GET: api/student_to_work/5
        [HttpGet("{id}")]
        public async Task<ActionResult<student_to_work>> Getstudent_to_work(int id)
        {
          if (_context.student_to_work == null)
          {
              return NotFound();
          }
            var student_to_work = await _context.student_to_work.FindAsync(id);

            if (student_to_work == null)
            {
                return NotFound();
            }

            return student_to_work;
        }


        // PUT: api/student_to_work/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putstudent_to_work(int id, student_to_work student_to_work)
        {
            if (id != student_to_work.Id)
            {
                return BadRequest();
            }

            _context.Entry(student_to_work).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!student_to_workExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/student_to_work
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<student_to_work>> Poststudent_to_work(student_to_work student_to_work)
        {
          if (_context.student_to_work == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.student_to_work'  is null.");
          }
            _context.student_to_work.Add(student_to_work);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getstudent_to_work", new { id = student_to_work.Id }, student_to_work);
        }

        // DELETE: api/student_to_work/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletestudent_to_work(int id)
        {
            if (_context.student_to_work == null)
            {
                return NotFound();
            }
            var student_to_work = await _context.student_to_work.FindAsync(id);
            if (student_to_work == null)
            {
                return NotFound();
            }

            _context.student_to_work.Remove(student_to_work);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool student_to_workExists(int id)
        {
            return (_context.student_to_work?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
