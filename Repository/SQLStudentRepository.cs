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

        //get all students
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await dbContext.Students.Include("Class").Include("Ranking").ToListAsync();
        }

        //get student by id 
        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            var studentDomainModel = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (studentDomainModel == null)
            {
                return null;
            }

            return studentDomainModel;
        }
    }
}
