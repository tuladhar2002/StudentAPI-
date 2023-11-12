using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace StudentAPI_Main.Domain.DTO
{
    public class UpdateStudentDto
    {
        [Required(ErrorMessage ="Name is required field")]
        [MinLength(1, ErrorMessage ="Min length for Name is 1")]
        public required string Name { get; set; }

        [Required(ErrorMessage ="Email is required field")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required feild")]
        public DateTime DOB { get; set; }

        public Guid? ClassId { get; set; }
        public Guid? RankingId { get; set; }
    }
}
