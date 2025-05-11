namespace Task_Management_System.Repository.Task
{
    public interface ITaskRepo
    {
        Task<IEnumerable<Models.Task>> GetAllAsync();
        Task<Models.Task> GetAsync(int id);
        Task<int> AddAsync(Models.Task task);
        Task<int> UpdateAsync(Models.Task task);
        Task<int> DeleteAsync(Models.Task task);

    }
}
