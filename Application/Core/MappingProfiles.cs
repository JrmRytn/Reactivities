using Application.Activities;
using Application.Comments;
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

            CreateMap<ActivityAttendee, AttendeeDto>()
                .ForMember(des => des.DisplayName, opt => opt.MapFrom(src => src.AppUser.DisplayName))
                .ForMember(des => des.Username, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ForMember(des => des.Bio, opt => opt.MapFrom(src => src.AppUser.Bio))
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<AppUser, Profiles.Profile>()
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));
            
            CreateMap<Comment, CommentDto>()
                .ForMember(des => des.DisplayName, opt => opt.MapFrom(src => src.Author.DisplayName))
                .ForMember(des => des.Username, opt => opt.MapFrom(src => src.Author.UserName))
                .ForMember(des => des.Image, opt => opt.MapFrom(s => s.Author.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}