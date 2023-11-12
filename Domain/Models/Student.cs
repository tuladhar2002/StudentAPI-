namespace StudentAPI_Main.Domain.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public DateTime DOB { get; set; }

        public Guid ClassId { get; set; }
        public Guid RankingId { get; set; }

        //Navigation Property 
        public Class Class { get; set; }
        public Ranking Ranking { get; set;}

    }
}
