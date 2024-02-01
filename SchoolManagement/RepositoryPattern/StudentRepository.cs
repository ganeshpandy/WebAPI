using Contracts;
using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class StudentRepository : IStudent
    {
        private readonly ContextDB _context;

        public StudentRepository(ContextDB context)
        {
            _context = context;
        }

        public async Task<StudentDetails> AddStudent(StudentDetails studentDetails)
        {
            var result = await _context.Students.AddAsync(studentDetails);
            await _context.SaveChangesAsync();
            return result.Entity;


        }
        public async Task<IEnumerable<StudentDetails>> GetStudent()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<StudentDetails> GetStudentById(int studentid)
        {
            return await _context.Students.FirstOrDefaultAsync(o => o.ID == studentid);
        }
        public async Task<StudentDetails> UpdateStudent(StudentDetails studentDetails)
        {
            var result = await _context.Students
                    .FirstOrDefaultAsync(C => C.ID == studentDetails.ID);
            if(result != null) 
            {
                result.StudentName = studentDetails.StudentName;
                result.PhoneNumber=studentDetails.PhoneNumber;
                result.PhoneNumber = studentDetails.PhoneNumber;
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<StudentDetails> DeleteStudent(int studentid)
        {
            var result = await _context.Students
              .FirstOrDefaultAsync(C => C.ID == studentid);

            if (result != null)
            {
                _context.Students.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        

       
    }
}
