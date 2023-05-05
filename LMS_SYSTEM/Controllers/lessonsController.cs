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
    public class lessonsController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public lessonsController(ApplicationDbContextApp context)
        {
            _context = context;
        }


        /// <summary>
        /// Tüm Derslerim Getirilmesi İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/lessons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<lessons>>> Getlessons()
        {
          if (_context.lessons == null)
          {
              return NotFound();
          }
            return await _context.lessons.ToListAsync();
        }

        /// <summary>
        /// Belirli bir Dersin Getirilmesi İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/lessons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<lessons>> Getlessons(int id)
        {
          if (_context.lessons == null)
          {
              return NotFound();
          }
            var lessons = await _context.lessons.FindAsync(id);

            if (lessons == null)
            {
                return NotFound();
            }

            return lessons;
        }

        /// <summary>
        /// Belirli bir Dersin Düzenlenmesi İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT: api/lessons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlessons(int id, lessons lessons)
        {
            if (id != lessons.Id)
            {
                return BadRequest();
            }

            _context.Entry(lessons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lessonsExists(id))
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


        /// <summary>
        /// Dersin Eklenmesi İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: api/lessons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<lessons>> Postlessons(lessons lessons)
        {
          if (_context.lessons == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.lessons'  is null.");
          }
            _context.lessons.Add(lessons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlessons", new { id = lessons.Id }, lessons);
        }

        /// <summary>
        /// Dersin Silinmesi İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/lessons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelessons(int id)
        {
            if (_context.lessons == null)
            {
                return NotFound();
            }
            var lessons = await _context.lessons.FindAsync(id);
            if (lessons == null)
            {
                return NotFound();
            }

            _context.lessons.Remove(lessons);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool lessonsExists(int id)
        {
            return (_context.lessons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
