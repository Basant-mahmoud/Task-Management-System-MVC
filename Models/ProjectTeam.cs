namespace Task_Management_System.Models
{
    public class ProjectTeam
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
