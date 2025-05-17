namespace Task_Management_System.Controllers.DTO
{
    public class GetTeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }

    }
}
