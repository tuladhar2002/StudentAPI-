using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI_Main.CustomActionFilters;
using StudentAPI_Main.Data;
using StudentAPI_Main.Domain.DTO;
using StudentAPI_Main.Domain.Models;
using StudentAPI_Main.Repository;

namespace StudentAPI_Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        //getAll Action
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var studentsDomainModel = await studentRepository.GetAllStudentsAsync();

                return Ok(mapper.Map<List<StudentDto>>(studentsDomainModel)); //200 with studentDTO
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Get student by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetStudentById([FromRoute] Guid id)
        {
            var studentDomainModel = await studentRepository.GetStudentByIdAsync(id);
            if (studentDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(studentDomainModel));
        }

        //POST req for creating student 

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto createStudentDto)
        {
           
            var studentDomainModel = mapper.Map<Student>(createStudentDto);

            var student = await studentRepository.CreateStudentsAsync(studentDomainModel);

            return CreatedAtAction(nameof(GetStudentById), new { id = studentDomainModel.Id }, createStudentDto);
           
          
        }

        //Delete Student
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var studentDomainModel = await studentRepository.DeleteStudentsAsync(id);

            if (studentDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<StudentDto>(studentDomainModel));
        }

        //Update Student
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, [FromBody] UpdateStudentDto updateStudentDto)
        {
           
            var studentDomainModel = mapper.Map<Student>(updateStudentDto);

            var student = await studentRepository.UpdateStudentsAsync(id, studentDomainModel);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<StudentDto>(student));
         
           
        }


    }
}
