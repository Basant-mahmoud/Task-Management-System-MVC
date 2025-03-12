using System.Net.Mail;
using Task_Management_System.Models.Enum;

namespace Task_Management_System.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public Enum.TaskStatus TaskStatus { get; set; }
        // forignkey
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public int? AssignedToId { get; set; }
        public User AssignedTo { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } 
        public virtual ICollection<Attachment> Attachments { get; set; } 
    }
}
