namespace Task_Management_System.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }  
        public string Action { get; set; }
        public string CreatedAt { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
