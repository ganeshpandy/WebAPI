using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IReport
    {
        Task<IEnumerable<Report>> GetAllStudents();
        Task<Report> GetStudentById(int Id);
        
        Task<Report> UpdateMark(MarkDetail markDetail);
    }
}
