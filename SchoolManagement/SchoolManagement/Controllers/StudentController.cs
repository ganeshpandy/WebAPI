using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent student;
        private readonly IMarkDetail markDetail;        
        private readonly IReport reports;        
        


        public StudentController(IMarkDetail markDetail, IStudent student)
        {
            this.markDetail = markDetail;
            this.student = student;            
        }        
        [HttpGet("GetStudent")]
        public async Task<IEnumerable<StudentDetails>> GetStudents()
        {
            var get = await student.GetStudent();
            return get;
        }
        [HttpGet("GetStudentById")]
        public async Task<StudentDetails> GetStudentById(int studentid)
        {
            var get = await student.GetStudentById(studentid);
            return get;
        }
        [HttpPost("AddStudent")]
        public async Task<StudentDetails> AddStudent(StudentDetails studentDetails) 
        {
            await student.AddStudent(studentDetails);            
            return studentDetails;
        }
        [HttpPut("UpdateStudent")]
        public async Task<StudentDetails> UpdateStudent(StudentDetails studentDetails)
        {
            var update = await student.UpdateStudent(studentDetails);
            return update;
        }
        [HttpDelete("DeleteUser")]
        public async Task DeleteUser(int studentid)
        {
            await student.DeleteStudent(studentid);
        }
        //==================================MarkController========================================
        [HttpGet("GetMark")]
        public async Task<IEnumerable<MarkDetail>> GetMarks()
        {
            var get = await markDetail.GetMark();
            return get;
        }
        [HttpGet("GetMarkById")]
        public async Task<MarkDetail> GetMarkById(int Id)
        {
            var get = await markDetail.GetMarkById(Id);
            return get;
        }
        [HttpPost("AddMark-Student")]
        public async Task<MarkDetail> AddMark(MarkDetail markDetail)
        {
            var update = await this.markDetail.AddMark(markDetail);
            return update;
        }
        //==================================ReportController========================================
        [HttpGet("GetAllStudent")]
        public async Task<IEnumerable<Report>> GetAllStudent()
        {
            var get = await reports.GetAllStudents();
            return get;
        }
        [HttpGet("GetReporttByID")]
        public async Task<Report> GetReporttByID(int Id)
        {
            var get = await reports.GetStudentById(Id);
            return get;
        }
        [HttpPut("UpdateMark")]
        public async Task<Report> UpdateStudentMark(MarkDetail markDetail)
        {
            var update = await reports.UpdateMark(markDetail);
            return update;
        }
    }
}
