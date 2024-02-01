using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStudent
    {
        Task<IEnumerable<StudentDetails>> GetStudent();
        Task<StudentDetails> GetStudentById(int studentid);
        Task<StudentDetails> AddStudent(StudentDetails studentDetails);
        Task<StudentDetails> UpdateStudent(StudentDetails studentDetails);
        Task<StudentDetails> DeleteStudent(int studentid);
        //Task<IQueryable<StudentDetails>> GetByRegisterNo(int regno);
    }
}
