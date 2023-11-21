using AutoMapper;
using CRUDApi.Dto;
using CRUDApi.Entities;
namespace CRUDApi.Profiles
{
    public class ItemProfile : Profile
    {
 public ItemProfile() 
        
        {
         CreateMap<Item,ItemDto>();
         CreateMap<ItemDto, Item>();
        
        }

    }
}
