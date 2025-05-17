using AutoMapper;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models.Enum;

namespace Task_Management_System.Services.Mappings
{
    public class TeanMappingProfile : Profile
    {
        public TeanMappingProfile()
        {
            /* CreateMap<UserDto, Models.User>();
             CreateMap<UserDto, Models.User>();
             CreateMap<Models.User, UserDto>(); */
            CreateMap<TeamDto, Models.Team>();
            CreateMap<Models.Team, TeamDto>();



        }
    }
}
