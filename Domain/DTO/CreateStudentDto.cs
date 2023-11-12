namespace StudentAPI_Main.Domain.DTO
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string email { get; set; }
        public DateTime DOB { get; set; }

        public Guid ClassId { get; set; }
        public Guid RankingId { get; set; }
    }
}
