namespace Task_Management_System.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; } // Active, Completed, OnHold

        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; }
        public virtual ICollection<Task> Tasks { get; set; } // one to meny project has many tasks
        public virtual ICollection<TeamMember> Members{ get; set; }
    }
}
