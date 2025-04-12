using Task_Management_System.Models.Enum;
using Task_Management_System.Models;
using TaskStatus = Task_Management_System.Models.Enum.TaskStatus;

namespace Task_Management_System.Controllers.DTO
{
    public class CreateTaskDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int CreatedById { get; set; }
        public int? AssignedToId { get; set; }
    }
}
