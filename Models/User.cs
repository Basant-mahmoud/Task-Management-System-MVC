namespace Task_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> CreatedTasks { get; set; }
        public virtual  ICollection<Task> AssignedTasks { get; set; } 
    }
}
