using Application.Activities;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity,Activity>(); 
            CreateMap<Activity, ActivityDto>()
            .ForMember(des => des.HostUsername, opt => opt.MapFrom(src => src.Attendees
                .FirstOrDefault(w => w.IsHost).AppUser.UserName))
            .ForMember(des=> des.Profiles , opt => opt.MapFrom(src => src.Attendees)); 

            CreateMap<ActivityAttendee, Profiles.Profile>()
                .ForMember(des => des.DisplayName, opt => opt.MapFrom(src => src.AppUser.DisplayName))
                .ForMember(des => des.Username, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ForMember(des => des.Bio, opt => opt.MapFrom(src => src.AppUser.Bio));
        }
    }
}