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
    public class usersController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public usersController(ApplicationDbContextApp context)
        {
            _context = context;
        }

        /// <summary>
        /// Tüm kullanıcıların Alınması İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<users>>> Getusers()
        {
          if (_context.users == null)
          {
              return NotFound();
          }
            return await _context.users.ToListAsync();
        }

        /// <summary>
        /// Belirli Bir Kullanıcının Alınması İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<users>> Getusers(int id)
        {
          if (_context.users == null)
          {
              return NotFound();
          }
            var users = await _context.users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }


        /// <summary>
        /// Belirli Bir Kullanıcının Düzenlenmesi İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT: api/users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putusers(int id, users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usersExists(id))
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
        /// Kullanıcı Ekleme İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<users>> Postusers(users users)
        {
          if (_context.users == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.users'  is null.");
          }
            _context.users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getusers", new { id = users.Id }, users);
        }

        /// <summary>
        /// Kullanıcı Silme İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteusers(int id)
        {
            if (_context.users == null)
            {
                return NotFound();
            }
            var users = await _context.users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool usersExists(int id)
        {
            return (_context.users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
