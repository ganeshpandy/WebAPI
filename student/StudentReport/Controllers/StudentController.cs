using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentContracts;
using StudentEntities.Data;
using StudentEntities.Model;

namespace StudentReport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMark _IMark;
        private readonly IStudent _IStudent;
        private readonly IStudentReport _IStudentReport;
        public StudentController(IMark iMark, IStudent iStudent, IStudentReport iStudentReport)
        {
            _IMark = iMark;
            _IStudent = iStudent;
            _IStudentReport = iStudentReport;
        }

        [HttpPost("AddStudent")]
        public async Task<Student> AddStudent([FromBody] Student student)
        {
            return await _IStudent.Add(student);
        }
        [HttpGet("GetStudents")]
        public async Task<IEnumerable<Student>> ReadStudent()
        {
            return await _IStudent.Read(); 
        }
        [HttpGet("GetStudentById")]

        public async Task<Student> ReadStudentById(int id)
        {
            return await _IStudent.ReadById(id);
        }

        [HttpPost("AddMark")]
        public async Task<Mark> AddMark(Mark mark)
        {
           return await _IMark.Add(mark);
        }

        [HttpGet("GetMarks")]
        public async Task<IEnumerable<Mark>> GetMark()
        {
            return await _IMark.Get();
        }

        [HttpPut("UpdateMark")]
        public async Task<Mark> UpdateMark(Mark mark)
        {
            return await _IMark.Update(mark);
        }
        [HttpGet("GetStudentReports")]
        public async Task<IEnumerable<StudentReports>> GetStudentReports()
        {
            return await _IStudentReport.Read();
        }

        [HttpGet("GetStudentReportByStudentId")]
        public async Task<StudentReports> GetStudentReportByStudentId(int id)
        {
            return await _IStudentReport.ReadById(id);
        }
    }

}
