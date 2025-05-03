namespace Task_Management_System.Models
{
    public class TaskAttachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }

        public int TaskId { get; set; } 
        public virtual Task Task { get; set; }

    }
}
