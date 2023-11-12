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
        public async Task<List<Student>> GetAllStudentsAsync(string? filterOn = null, string? filterQuery = null,
             string? sortBy = null, bool isAscending = true)
        {
           
            var students = dbContext.Students.Include("Class").Include("Ranking").AsQueryable();

            //filtering
            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery)==false)
            {
                //filter by name
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase)) //check if the entity 'Name' is present in DBS & ignorecase
                {
                    students = students.Where(x => x.Name.Contains(filterQuery)); //checks each dbs row 'Name' entity with filterQuery field and stores if equals within students
                }
                //filter by email
                if (filterOn.Equals("Email", StringComparison.OrdinalIgnoreCase)) //check if the entity 'Email' is present in DBS & ignorecase
                {
                    students = students.Where(x => x.Email.Contains(filterQuery)); //checks each dbs row 'Email' entity with filterQuery field and stores if equals within students
                }
            }

            //sorting
             if(string.IsNullOrWhiteSpace(sortBy)==false) //check sortBy if is empty
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)) //check if sortBy Name
                {
                    students = isAscending ? students.OrderBy(x => x.Name): students.OrderByDescending(x=>x.Name);
                }
            }
              

            return await students.ToListAsync(); //return in list format
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
