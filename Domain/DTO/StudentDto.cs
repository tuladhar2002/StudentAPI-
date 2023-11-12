using StudentAPI_Main.Domain.Models;

namespace StudentAPI_Main.Domain.DTO
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public DateTime DOB { get; set; }

        // removed guid values
        //
        //

        public ClassDto Class { get; set; }
        public RankingDto Ranking {  get; set; } 
    }
}
