using Task_Management_System.Models.Enum;

namespace Task_Management_System.Controllers.DTO
{
    public class ProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectStatus Status { get; set; } // Active, Completed, OnHold

        public int? TeamId { get; set; }
    }
}
