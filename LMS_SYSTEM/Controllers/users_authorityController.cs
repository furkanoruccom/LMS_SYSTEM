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
    public class users_authorityController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public users_authorityController(ApplicationDbContextApp context)
        {
            _context = context;
        }

        // GET: api/users_authority
        [HttpGet]
        public async Task<ActionResult<IEnumerable<users_authority>>> Getusers_authority()
        {
          if (_context.users_authority == null)
          {
              return NotFound();
          }
            return await _context.users_authority.ToListAsync();
        }

        // GET: api/users_authority/5
        [HttpGet("{id}")]
        public async Task<ActionResult<users_authority>> Getusers_authority(int id)
        {
          if (_context.users_authority == null)
          {
              return NotFound();
          }
            var users_authority = await _context.users_authority.FindAsync(id);

            if (users_authority == null)
            {
                return NotFound();
            }

            return users_authority;
        }

        // PUT: api/users_authority/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putusers_authority(int id, users_authority users_authority)
        {
            if (id != users_authority.Id)
            {
                return BadRequest();
            }

            _context.Entry(users_authority).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!users_authorityExists(id))
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

        // POST: api/users_authority
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<users_authority>> Postusers_authority(users_authority users_authority)
        {
          if (_context.users_authority == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.users_authority'  is null.");
          }
            _context.users_authority.Add(users_authority);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getusers_authority", new { id = users_authority.Id }, users_authority);
        }

        // DELETE: api/users_authority/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteusers_authority(int id)
        {
            if (_context.users_authority == null)
            {
                return NotFound();
            }
            var users_authority = await _context.users_authority.FindAsync(id);
            if (users_authority == null)
            {
                return NotFound();
            }

            _context.users_authority.Remove(users_authority);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool users_authorityExists(int id)
        {
            return (_context.users_authority?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
