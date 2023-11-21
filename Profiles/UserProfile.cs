using AutoMapper;
using CRUDApi.Entities;
using CRUDApi.Dto;
namespace CRUDApi.Profiles
{
    public class UserProfile  : Profile
    {
      public UserProfile() 
        {
        CreateMap<User, UserDto>();
        CreateMap<UserDto,User>();
        }
    }
}
