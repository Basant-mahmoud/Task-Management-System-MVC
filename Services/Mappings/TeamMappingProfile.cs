using AutoMapper;
using Task_Management_System.Controllers.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Enum;

namespace Task_Management_System.Services.Mappings
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
           
            CreateMap<TeamDto, Models.Team>();
            CreateMap<Models.Team, TeamDto>();
            CreateMap<Models.TeamMember, AddMemberDto>();
            


        }
    }
}
