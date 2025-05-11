namespace Task_Management_System.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string IsLeader { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }


    }
}
