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
    public class school_workController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public school_workController(ApplicationDbContextApp context)
        {
            _context = context;
        }


        /// <summary>
        /// Tüm Ödevlerin Getirilmesi İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/school_work
        [HttpGet]
        public async Task<ActionResult<IEnumerable<school_work>>> Getschool_work()
        {
            if (_context.school_work == null)
            {
                return NotFound();
            }
            return await _context.school_work.ToListAsync();
        }



        /// <summary>
        /// Belir bir Id ye Göre Ödev alma işlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/school_work/5
        [HttpGet("{id}")]
        public async Task<ActionResult<school_work>> Getschool_work(int id)
        {
            if (_context.school_work == null)
            {
                return NotFound();
            }
            var school_work = await _context.school_work.FindAsync(id);

            if (school_work == null)
            {
                return NotFound();
            }

            return school_work;
        }


        /// <summary>
        /// Ödev Düzenleme İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT: api/school_work/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putschool_work(int id, school_work school_work)
        {
            if (id != school_work.Id)
            {
                return BadRequest();
            }

            _context.Entry(school_work).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!school_workExists(id))
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
        /// Ödevi Ekleme İşlemi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: api/school_work
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<school_work>> Postschool_work(school_work school_work)
        {
            if (_context.school_work == null)
            {
                return Problem("Entity set 'ApplicationDbContextApp.school_work'  is null.");
            }
            _context.school_work.Add(school_work);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getschool_work", new { id = school_work.Id }, school_work);
        }
        /// <summary>
        /// Ödevin silinmesi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/school_work/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteschool_work(int id)
        {
            if (_context.school_work == null)
            {
                return NotFound();
            }
            var school_work = await _context.school_work.FindAsync(id);
            if (school_work == null)
            {
                return NotFound();
            }

            _context.school_work.Remove(school_work);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool school_workExists(int id)
        {
            return (_context.school_work?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        /// <summary>
        /// Öğrenci Id verildiğinde o ögrenciye ait ödevlerin getilmesi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("student/{id}")]
        public async Task<ActionResult<List<school_work>>> GetStudentAssignments(int id)
        {
            var studentAssignments = await _context.student_to_work.Where(stw => stw.studentId == id).ToListAsync();
            List<school_work> workList = new List<school_work>();
            foreach (var item in studentAssignments)
            {
                var work = await _context.school_work.FirstOrDefaultAsync(i => i.Id == item.workId);
                if (work != null)
                {
                    school_work yeni = new school_work();
                    yeni.work_name = work.work_name;
                    yeni.teacherId = work.teacherId;
                    yeni.Id = work.Id;
                    workList.Add(yeni);
                }
            }

            if (workList.Count == 0)
            {
                return NotFound();
            }

            return workList;
        }
    }
}
