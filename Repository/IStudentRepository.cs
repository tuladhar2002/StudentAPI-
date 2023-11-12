using StudentAPI_Main.Domain.Models;

namespace StudentAPI_Main.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync(string? filterOn=null, string? filterQuery=null);
        Task<Student?> GetStudentByIdAsync(Guid id);
        Task<Student> CreateStudentsAsync(Student student);

        Task<Student?> UpdateStudentsAsync(Guid studentId, Student students);

        Task<Student?> DeleteStudentsAsync(Guid id);
    }
}

