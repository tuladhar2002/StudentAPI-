using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StudentAPI_Main.Data;
using StudentAPI_Main.Domain.Models;

namespace StudentAPI_Main.Repository
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly StudentAPIDbContext dbContext;

        public SQLStudentRepository(StudentAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //create students
        public async Task<Student> CreateStudentsAsync(Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return student;
        }

        //Delete Student
        public async Task<Student?> DeleteStudentsAsync(Guid id)
        {
            var studentDomainModel = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (studentDomainModel == null)
            {
                return null;
            }

            dbContext.Students.Remove(studentDomainModel);
            await dbContext.SaveChangesAsync();

            return studentDomainModel;
        }

        //get all students
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await dbContext.Students.Include("Class").Include("Ranking").ToListAsync();
        }

        //get student by id 
        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            var studentDomainModel = await dbContext.Students.Include("Class").Include("Ranking").FirstOrDefaultAsync(x => x.Id == id);

            if (studentDomainModel == null)
            {
                return null;
            }

            return studentDomainModel;
        }
        //update student
        public async Task<Student?> UpdateStudentsAsync(Guid studentId, Student student)
        {
            var studentDomainModel = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == studentId);

            if (studentDomainModel == null)
            {
                return null;
            }

            studentDomainModel.Name = student.Name;
            studentDomainModel.Email = student.Email;
            studentDomainModel.DOB = student.DOB;
            studentDomainModel.ClassId = student.ClassId;
            studentDomainModel.Ranking = student.Ranking;

            await dbContext.SaveChangesAsync();

            return studentDomainModel;
        }
    }
}
