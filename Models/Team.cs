using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Task_Management_System.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TeamMember> Members { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
