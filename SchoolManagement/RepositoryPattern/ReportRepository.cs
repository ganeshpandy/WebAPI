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
    public class ReportRepository : IReport
    {
        private readonly ContextDB _context;

        public ReportRepository(ContextDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Report>> GetAllStudents()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<Report> GetStudentById(int Id)
        {
            return await _context.Reports
               .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Report> UpdateMark(MarkDetail markDetail)
        {
            var result = await _context.Reports
                    .FirstOrDefaultAsync(C => C.Id == markDetail.MarkId);
            if (result != null)
            {
                result.Id = markDetail.MarkId;
                result.RegisterNo = markDetail.MarkId;
                result.StudentName = markDetail.StudentDetails.StudentName;
                result.TotalMark = markDetail.Tamil + markDetail.English + markDetail.Maths + markDetail.Science + markDetail.Social;
                return result;
            }
            return null;
        }
    }
}
