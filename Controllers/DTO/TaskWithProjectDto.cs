namespace Task_Management_System.Controllers.DTO
{
    public class TaskWithProjectDto
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskStatus { get; set; }
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
    }
}
