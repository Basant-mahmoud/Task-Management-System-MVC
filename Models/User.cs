using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // Admin, Leader, Member
        public DateTime CreatedAt { get; set; }

        public ICollection<TeamMember> TeamMemberships { get; set; }
        public ICollection<Task> AssignedTasks { get; set; }
        public ICollection<Task> CreatedTasks { get; set; }
        public ICollection<TaskComment> Comments { get; set; }
        public ICollection<ActivityLog> Logs { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
