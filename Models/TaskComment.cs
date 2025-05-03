using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
    public class TaskComment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public String CreatedAt { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
