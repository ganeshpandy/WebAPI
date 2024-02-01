using StudentEntities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentContracts
{
    public interface IStudent
    {
        public Task<Student> Add(Student student);
        public Task<IEnumerable<Student>> Read();
        public Task<Student> ReadById(int id);
        //public Task<Student> Update(Student student);
        public Task<Student> Delete(int id);
    }
}
