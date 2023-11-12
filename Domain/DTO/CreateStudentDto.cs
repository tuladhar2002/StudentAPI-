using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace StudentAPI_Main.Domain.DTO
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage ="Name is a required field")]
        [MinLength(1, ErrorMessage = "Name has to be more than 1 character")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is required field")]
        [EmailAddress(ErrorMessage ="Not valid email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required feild")]
        public DateTime DOB { get; set; }

        public Guid? ClassId { get; set; }
        public Guid? RankingId { get; set; }
    }
}
