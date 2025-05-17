using Task_Management_System.Models.Enum;

namespace Task_Management_System.Controllers.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public  UserRole Role{ get; set; } 
        public string CreatedAt { get; set; }
    }
}
