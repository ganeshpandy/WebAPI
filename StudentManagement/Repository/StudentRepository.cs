using Microsoft.EntityFrameworkCore;
using StudentContracts;
using StudentEntities.Data;
using StudentEntities.Model;

namespace StudentRepositories
{
    public class StudentRepository : IStudent, IMark, IStudentReport
    {
        private readonly StudentContext _contextDB;
        public StudentRepository(StudentContext contextDB)
        {
            _contextDB = contextDB;
        }

        public async Task<Student> Add(Student student)
        {
            var addUser = await _contextDB.StudentDetail.AddAsync(student);
            await _contextDB.SaveChangesAsync();
            return addUser.Entity;
        }
        public async Task<IEnumerable<Student>> Read()
        {
            return await _contextDB.StudentDetail.ToListAsync();
        }

        public async Task<Student> ReadById(int id)
        {
            return await _contextDB.StudentDetail.FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        public async Task<Student> Delete(int id)
        {
            var result = await _contextDB.StudentDetail.FirstOrDefaultAsync(t => t.Id.Equals(id));
            if (result != null)
            {
                result.IsDeleted = false;
                await _contextDB.SaveChangesAsync();
            }
            return null;
        }

        public async Task<Mark> Add(Mark mark)
        {
            var GetStudent = await _contextDB.StudentDetail.FirstOrDefaultAsync(t => t.Id.Equals(mark.StudentId));
            if(GetStudent != null)
            {
               
                    Student getStudent = GetStudent;
                    mark.Student = getStudent;
                    
                var addUser = await _contextDB.Marks.AddAsync(mark);
                await _contextDB.SaveChangesAsync();
                await AddStudentReport(mark);
                return addUser.Entity;
            }
            return null;
        }

        public async Task<StudentReports> AddStudentReport(Mark mark)
        {
            StudentReports studentReport = new StudentReports();

            StudentReports studentReportt = Calculation(studentReport, mark);
            
            var addReport = await _contextDB.Report.AddAsync(studentReportt);
            await _contextDB.SaveChangesAsync();
            return addReport.Entity;
        }

        public StudentReports Calculation(StudentReports studentReport, Mark mark)
        {
            studentReport.MarkId = mark.Id;

            studentReport.Mark = mark;

            studentReport.TotalMark = mark.TamilMark + mark.EnglishMark + mark.MathsMark +
                              mark.ScienceMark + mark.SocialMark;

            studentReport.Percentage = studentReport.TotalMark / 500 * 100;

            bool isResult = false;

            studentReport.Grade = "Fail";

            if (mark.TamilMark >= 40 && mark.EnglishMark >= 40 && mark.MathsMark >= 40
                              && mark.ScienceMark >= 40 && mark.SocialMark >= 40)
            {
                isResult = true;
            }
            if (isResult)
            {
                if (studentReport.TotalMark >= 300 && studentReport.TotalMark < 400)
                {
                    studentReport.Grade = "First Class";
                }
                else if (studentReport.TotalMark >= 400 && studentReport.TotalMark < 500)
                {
                    studentReport.Grade = "Distniction";
                }
                else if (studentReport.TotalMark == 500)
                {
                    studentReport.Grade = "State First";
                }
            }
            return studentReport;
        }
        public async Task<IEnumerable<Mark>> Get()
        {
            var getMark = await _contextDB.Marks.ToListAsync();
            List<Mark> markList = new List<Mark>();

            foreach (Mark value in getMark)
            {
                var student = await _contextDB.StudentDetail.FirstOrDefaultAsync(range => range.Id.Equals(value.StudentId));

                if (student != null)
                {
                    value.Student = student;
                    markList.Add(value);
                }
            }
            return markList;
        }
        public async Task<Mark?> Update(Mark mark)
        {
            var result = await _contextDB.Marks.FirstOrDefaultAsync(t => 
                                t.StudentId.Equals(mark.StudentId));

            if (result != null)
            {
                if(!mark.TamilMark.Equals(0))
                {
                    result.TamilMark = mark.TamilMark;
                }
                if(!mark.EnglishMark.Equals(0))
                {
                    result.EnglishMark = mark.EnglishMark;
                }
                if(!mark.MathsMark.Equals(0))
                {
                    result.MathsMark = mark.MathsMark;
                }
                if(!mark.ScienceMark.Equals(0))
                {
                    result.ScienceMark = mark.ScienceMark;
                }
                if(!mark.SocialMark.Equals(0))
                {
                    result.SocialMark = mark.SocialMark;
                }

                await _contextDB.SaveChangesAsync();
            }
            if(_contextDB.Report.Count() > 0)
            {
                if(result!=null)
                {
                    var change = await _contextDB.Report.FirstOrDefaultAsync(t =>
                               t.MarkId.Equals(result.Id));
                    if(change!=null)
                    {
                        StudentReports reports = Calculation(change, result);
                        await _contextDB.SaveChangesAsync();
                    }
                }
               

            }
            return result;

        }

        async Task<IEnumerable<StudentReports>> IStudentReport.Read()
        {
            return await _contextDB.Report.ToListAsync();
        }

        async Task<StudentReports> IStudentReport.ReadById(int id)
        {
            return await _contextDB.Report.FirstOrDefaultAsync(t => t.MarkId.Equals(id));
        }
    }
}