using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS_SYSTEM.Data;
using LMS_SYSTEM.Models;

namespace LMS_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class teacher_to_lessonController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public teacher_to_lessonController(ApplicationDbContextApp context)
        {
            _context = context;
        }

        // GET: api/teacher_to_lesson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<teacher_to_lesson>>> Getteacher_to_lesson()
        {
          if (_context.teacher_to_lesson == null)
          {
              return NotFound();
          }
            return await _context.teacher_to_lesson.ToListAsync();
        }

        // GET: api/teacher_to_lesson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<teacher_to_lesson>> Getteacher_to_lesson(int id)
        {
          if (_context.teacher_to_lesson == null)
          {
              return NotFound();
          }
            var teacher_to_lesson = await _context.teacher_to_lesson.FindAsync(id);

            if (teacher_to_lesson == null)
            {
                return NotFound();
            }

            return teacher_to_lesson;
        }

        // PUT: api/teacher_to_lesson/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putteacher_to_lesson(int id, teacher_to_lesson teacher_to_lesson)
        {
            if (id != teacher_to_lesson.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher_to_lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teacher_to_lessonExists(id))
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

        // POST: api/teacher_to_lesson
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<teacher_to_lesson>> Postteacher_to_lesson(teacher_to_lesson teacher_to_lesson)
        {
          if (_context.teacher_to_lesson == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.teacher_to_lesson'  is null.");
          }
            _context.teacher_to_lesson.Add(teacher_to_lesson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getteacher_to_lesson", new { id = teacher_to_lesson.Id }, teacher_to_lesson);
        }

        // DELETE: api/teacher_to_lesson/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteteacher_to_lesson(int id)
        {
            if (_context.teacher_to_lesson == null)
            {
                return NotFound();
            }
            var teacher_to_lesson = await _context.teacher_to_lesson.FindAsync(id);
            if (teacher_to_lesson == null)
            {
                return NotFound();
            }

            _context.teacher_to_lesson.Remove(teacher_to_lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool teacher_to_lessonExists(int id)
        {
            return (_context.teacher_to_lesson?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
