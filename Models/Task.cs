using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Task_Management_System.Models.Enum;

namespace Task_Management_System.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; } // High, Medium, Low
        public string Status { get; set; } // ToDo, InProgress, Done
        public DateTime DueDate { get; set; }

        public int AssignedToUserId { get; set; } // user asign to many tasks
        public User AssignedToUser { get; set; }

        public int CreatedByUserId { get; set; } // user can create many tasks
        public User CreatedByUser { get; set; }

        public int ProjectId { get; set; } // task related to one project
        public Project Project { get; set; }

        public ICollection<TaskAttachment> Attachments { get; set; } // task has many attachment
        public ICollection<TaskComment> Comments { get; set; } // task has many comment 
    }
}
