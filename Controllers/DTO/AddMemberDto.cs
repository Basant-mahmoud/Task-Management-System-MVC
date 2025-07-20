namespace Task_Management_System.Controllers.DTO
{
    public class AddMemberDto
    {
        public List<int> UserId { get; set; }
        public int TeamId { get; set; }
        public bool IsLeader { get; set; }
        public int ProjectId { get; set; }


    }
}
