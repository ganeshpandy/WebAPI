using StudentEntities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentContracts
{
    public interface IStudentReport
    {
        public Task<IEnumerable<StudentReports>> Read();
        public Task<StudentReports> ReadById(int id);
    }
}
