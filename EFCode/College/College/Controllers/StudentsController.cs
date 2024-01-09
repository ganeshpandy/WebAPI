using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using College.Data;
using College.Models;
using System.Diagnostics;

namespace College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CollegeContext _context;

        public StudentsController(CollegeContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get_student()
        {
            return await _context._student.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context._student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
        // GET: api/Students/
        [HttpGet("Innerjoin")]
        public async Task<ActionResult<object>> Innerjoin()
        {
            var innerJoin = from stud in _context._student
                            join teach in _context._staff
                            on stud.StaffId equals teach.StaffId 
                            select new Output
                            {
                                SId = stud.StudId,
                                SName = stud.StudName,
                                SEmail=stud.Email,
                                TeachId=teach.StaffId,
                                TeachName = teach.StaffName

                            };

            return innerJoin.ToList();
        }
        [HttpGet("leftJoin")]
        public async Task<ActionResult<object>> leftJoin()
        {
            var leftJoin = from stud in _context._student
                           join teach in _context._staff
                           on stud.StaffId equals teach.StaffId into StudGroup
                           from p in StudGroup.DefaultIfEmpty()
                           select new Output
                           {
                               SId = stud.StudId,
                               SName = stud.StudName,
                               TeachName = p.StaffName,
                               //Subject = p.Subject
                               //Subject = p != null ? p.Subject : 0 
                           };

            return leftJoin.ToList();
        }
        [HttpGet("rightjoin")]
        public async Task<ActionResult<object>> rightjoin()
        {
            var rightjoin = from teach in _context._staff
                           join stud in _context._student
                           on teach.StaffId equals stud.StaffId into StudGroup
                           from p in StudGroup.DefaultIfEmpty()
                           select new Output
                           {
                               TeachName = teach.StaffName,
                               SName = p.StudName,
                               SEmail = p != null ? p.Email : "Null"                               
                           };

            return rightjoin.ToList();
        }
        [HttpGet("fulljoin")]
        public async Task<ActionResult<object>> FullJoin()
        {
            var leftJoin = from stud in _context._student
                           join teach in _context._staff
                           on stud.StaffId equals teach.StaffId into StudGroup
                           from p in StudGroup.DefaultIfEmpty()
                           select new Output
                           {
                               SId = stud.StudId,
                               SName = stud.StudName,
                               TeachName = p.StaffName,
                               Subject = p != null ? p.Subject : 0
                           };

            var rightJoin = from teach in _context._staff
                            join stud in _context._student
                            on teach.StaffId equals stud.StaffId into StudGroup
                            from p in StudGroup.DefaultIfEmpty()
                            select new Output
                            {
                                TeachName = teach.StaffName,
                                SName = p.StudName,
                                SEmail = p != null ? p.Email : "Null"
                            };

            var fullJoin = leftJoin.Union(rightJoin);

            return fullJoin.ToList();
        }
       

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudId)
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context._student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.StudId }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context._student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context._student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context._student.Any(e => e.StudId == id);
        }
    }
}
