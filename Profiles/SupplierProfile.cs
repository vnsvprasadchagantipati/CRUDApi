using AutoMapper;
using CRUDApi.Entities;
using CRUDApi.Dto;
namespace CRUDApi.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile() 
        {
          CreateMap<Supplier, SupplierDto>();
          CreateMap<SupplierDto, Supplier>();
        }

    }
}
