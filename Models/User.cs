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
        public string CreatedAt { get; set; }

        public virtual  ICollection<TeamMember> TeamMemberships { get; set; }
        public virtual ICollection<Task> AssignedTasks { get; set; }
        public virtual ICollection<Task> CreatedTasks { get; set; }
        public virtual ICollection<TaskComment> Comments { get; set; }
        public virtual ICollection<ActivityLog> Logs { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
