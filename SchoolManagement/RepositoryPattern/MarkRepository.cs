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
    public class MarkRepository : IMarkDetail
    {
        private readonly ContextDB _context;

        public MarkRepository(ContextDB context)
        {
            _context = context;
        }

        public async Task<MarkDetail> AddMark(MarkDetail mark)
        {          
                var addUser = await _context.Marks.AddAsync(mark);
                await _context.SaveChangesAsync();
            MarkDetail mk = await AddStudentReport(mark);                
                return mk;
          
        }
        public async Task<MarkDetail> AddStudentReport(MarkDetail mark)
        {
          
           Report _Report=new Report();
            //_Report.Id = mark.MarkId;
            _Report.MarkDetail = mark;
            var result=await _context.Students.FirstOrDefaultAsync(m=>m.ID==mark.StudentDetailsId);
            _Report.StudentName = result.StudentName;
            _Report.RegisterNo = result.ID;


            _Report.TotalMark = mark.Tamil + mark.English + mark.Maths + mark.Science + mark.Social;

            _Report.Percentage = (mark.Tamil + mark.English + mark.Maths + mark.Science + mark.Social) / 5;
            bool isResult = false;

            _Report.Grade = "Fail";

            if (mark.Tamil >= 40 && mark.English >= 40 && mark.Maths >= 40 && mark.Science >= 40 && mark.Social >= 40)
            {
                isResult = true;
            }
            if (isResult)
            {
                if (_Report.TotalMark >= 300)
                {
                    _Report.Grade = "First Class";
                }
                else if (_Report.TotalMark >= 400)
                {
                    _Report.Grade = "Distniction";
                }
                else if (_Report.TotalMark == 500)
                {
                    _Report.Grade = "State First";
                }
            }
            await _context.Reports.AddAsync(_Report);
            await _context.SaveChangesAsync();
            return mark;
        }

        public async Task<IEnumerable<MarkDetail>> GetMark()
        {
            return await _context.Marks.ToListAsync();
        }

        public async Task<MarkDetail> GetMarkById(int Id)
        {
            return await _context.Marks
                 .FirstOrDefaultAsync(c => c.MarkId == Id);
        }

        public async Task<MarkDetail> UpdateMark(MarkDetail markDetail)
        {
            var result = await _context.Marks
                   .FirstOrDefaultAsync(C => C.MarkId == markDetail.MarkId);
            if (result!=null) 
            {
                result.Tamil=markDetail.Tamil;
                result.English = markDetail.English;
                result.Maths=markDetail.Maths;
                result.Science=markDetail.Science;
                result.Social=markDetail.Social;
                await _context.SaveChangesAsync();

                return result;
            }
            return result;

        }
    }
}
