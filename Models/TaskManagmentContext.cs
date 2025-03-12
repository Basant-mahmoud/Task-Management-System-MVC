using Microsoft.EntityFrameworkCore;

namespace Task_Management_System.Models
{
    public class TaskManagmentContext : DbContext
    {
        public TaskManagmentContext(DbContextOptions<TaskManagmentContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.CreatedBy)
                .WithMany()  // If a user can create multiple tasks, but no navigation property in User
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Task>()
                .HasOne(t => t.AssignedTo)
                .WithMany() // If a user can be assigned multiple tasks
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent unintentional deletes

            base.OnModelCreating(modelBuilder);
        }


    }
}
