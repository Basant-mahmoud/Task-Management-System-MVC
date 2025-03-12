namespace Task_Management_System.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime UploadedAt { get; set; }
        //forign
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
