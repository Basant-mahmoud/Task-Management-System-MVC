using Task_Management_System.Controllers.DTO;

namespace Task_Management_System.Services.User

{
    public interface IUserService
    {
        Task<int> AddAsync(CreateUserDTO userdto);
        Task<int> UpdateAsync(int id, UserDto updateduser);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetAsync(int id);
    }
}
