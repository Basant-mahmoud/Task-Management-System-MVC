namespace Task_Management_System.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }  
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
