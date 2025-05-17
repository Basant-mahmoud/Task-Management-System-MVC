using AutoMapper;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Enum;

namespace Task_Management_System.Services.Mappings
{
    public class TeamMappingProfile: Profile
    {
        public TeamMappingProfile()
        {
            /* CreateMap<UserDto, Models.User>();
             CreateMap<UserDto, Models.User>();
             CreateMap<Models.User, UserDto>(); */

            // becase i make enum and want to store enum as string not enum
            //            // من User (string Role) إلى UserDto (enum Role)
            CreateMap<CreateUserDTO, Models.User>()
         .ForMember(dest => dest.Role,
               opt => opt.MapFrom(src => src.Role.ToString()));



            CreateMap<Models.User, UserDto>()
            .ForMember(dest => dest.Role,
            opt => opt.MapFrom(src => Enum.Parse<UserRole>(src.Role, true)));


            CreateMap<UserDto, Models.User>()
          .ForMember(dest => dest.Role,
               opt => opt.MapFrom(src => src.Role.ToString()));

            // CreateMap<UserDto, Models.User>();


        }
    }
}

