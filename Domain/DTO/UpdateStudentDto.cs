namespace StudentAPI_Main.Domain.DTO
{
    public class UpdateStudentDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public DateTime DOB { get; set; }

        public Guid ClassId { get; set; }
        public Guid RankingId { get; set; }
    }
}
