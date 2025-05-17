namespace Task_Management_System.Controllers.DTO
{
    public class TeamWithTasksAndProjectsDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public List<TaskWithProjectDto> Tasks { get; set; }
    }
}
