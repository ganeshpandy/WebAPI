using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDetails.Models;

namespace StudentDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SqlContext _context;

        public StudentsController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
          if (_context.Students == null)
          {
              return NotFound();
          }
            var displayTable = _context.Students
                              .FromSql($"EXECUTE dbo.GetStudent")
                              .ToList();
            return await _context.Students.ToListAsync();
        }

        [HttpGet("GetStudentById")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentById()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }

            int SId = 12;
            var studId =_context.Students.FromSql($"EXECUTE dbo.GetStudentById {SId}").ToList();
            return studId;
            
        }

        

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        [HttpPut("PutStudent")]
        public async Task<ActionResult<IEnumerable<Student>>> PutStudent()
        {

            string Address = "egmore";
            int SId = 0;


            var update = _context.Database.ExecuteSql($"dbo.PutStudent @Id={SId},@Address={Address}");
            return _context.Students;
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
          if (_context.Students == null)
          {
              return Problem("Entity set 'SqlContext.Students'  is null.");
          }
            _context.Students.Add(student);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }
        [HttpPost("SaveTrainingStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> AddStudent()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            string Name = "sugan";
            int SId = 1;


            var stdList = _context.Database.ExecuteSql($"dbo.AddStudent @Name={Name},@StaffId={SId}");
            return _context.Students;
        }

        // DELETE: api/Students/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
