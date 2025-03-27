using AutoMapper;
using DatingApp.DTOs;
using DatingApp.Entites;

namespace DatingApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDTO>().ForMember(dest => dest.PhotoURL, opt => opt.MapFrom(source => source.Photos.FirstOrDefault(photo => photo.IsMain).Url));
            CreateMap<Photo, PhotoDTO>();
        }
    }
}
