using Task_Management_System.Controllers.DTO;

namespace Task_Management_System.Controllers.DTO
{
    public class UserInfoDto
    {
        public UserDto User { get; set; }
        public List<TeamWithTasksAndProjectsDto> Teams { get; set; }
    }
}

