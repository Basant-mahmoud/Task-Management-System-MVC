namespace Task_Management_System.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string IsEmailSent { get; set; }
    }
}
