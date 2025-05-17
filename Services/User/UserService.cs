using AutoMapper;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task_Management_System.Repository.User;

namespace Task_Management_System.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;  
            _mapper = mapper;
        }
        public async Task<int> AddAsync(CreateUserDTO userdto)
        {
            try
            {
                var user = _mapper.Map<Models.User>(userdto);
                var result = await _userRepo.AddAsync(user);
                if (result == 0)
                    throw new Exception("Error occurred while adding the user.");

                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while adding the user.", ex);
            }

        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var olduser = await _userRepo.GetAsync(id);
                if (olduser == null)
                    throw new Exception("Error user not in system");
                var deleteduser = await _userRepo.UpdateAsync(olduser);
                if(deleteduser==0)
                    throw new Exception("Error Cant delete User");

                return deleteduser;

            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleteing the user.", ex);
            }

        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            try
            {
                var usersmodel = await _userRepo.GetAllAsync();
                if (!usersmodel.Any())
                {
                    return new List<UserDto>();
                }
                var userDtos = _mapper.Map<IEnumerable<UserDto>>(usersmodel);
                return userDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while Geting  all user.", ex);
            }

        }

        public async Task<UserDto> GetAsync(int id)
        {
            try
            {
                var usermodel = await _userRepo.GetAsync(id);
                if(usermodel==null)
                    throw new Exception("Error user not found");
                var userDto = _mapper.Map<UserDto>(usermodel);
                return userDto;

            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while Geting this user.", ex);
            }
        }

        public async Task<UserInfoDto> GetUserTeamsWithTasksAndProjectsAsync(int userId)
        {
            try
            {
                var user = await _userRepo.GetAsync(userId);
                if (user == null)
                    throw new Exception("Can't find this user");

                var result = await _userRepo.GetUserTeamsWithTasksAndProjectsAsync(userId);

                var userDto = _mapper.Map<UserDto>(user); 

                return new UserInfoDto
                {
                    User = userDto,
                    Teams = result
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching user info.", ex);
            }
        }


        public async Task<int> UpdateAsync(int id, UserDto updatedUserDto)
        {
            try
            {
                var oldUser = await _userRepo.GetAsync(id);
                if (oldUser == null)
                    throw new Exception("User not found");

                // Map updatedUserDto onto oldUser entity to keep tracking
                _mapper.Map(updatedUserDto, oldUser);

                var result = await _userRepo.UpdateAsync(oldUser);
                if (result == 0)
                    throw new Exception("Error while updating this user");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating this user.", ex);
            }
        }

    }
}
