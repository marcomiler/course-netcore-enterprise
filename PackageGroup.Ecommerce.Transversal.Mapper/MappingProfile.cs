using AutoMapper;
using PackageGroup.Ecommerce.Application.DTO;
using PackageGroup.Ecommerce.Domain.Entity;

namespace PackageGroup.Ecommerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //TODO: AMBAS FORMAS SON EQUIVALENTES
            CreateMap<Customers, CustomerDTO>().ReverseMap();
            //CreateMap<Customers, CustomerDTO>()
            //    .ForMember(d => d.CustomerId, o => o.MapFrom(x => x.CustomerId))
            //    .ForMember(d => d.CompanyName, o => o.MapFrom(x => x.CompanyName))
            //    .ForMember(d => d.ContactName, o => o.MapFrom(x => x.ContactName))
            //    .ForMember(d => d.ContactTitle, o => o.MapFrom(x => x.ContactTitle))
            //    .ForMember(d => d.Address, o => o.MapFrom(x => x.Address))
            //    .ForMember(d => d.City, o => o.MapFrom(x => x.City))
            //    .ForMember(d => d.Region, o => o.MapFrom(x => x.Region))
            //    .ForMember(d => d.PostalCode, o => o.MapFrom(x => x.PostalCode))
            //    .ForMember(d => d.Country, o => o.MapFrom(x => x.Country))
            //    .ForMember(d => d.Phone, o => o.MapFrom(x => x.Phone))
            //    .ForMember(d => d.Fax, o => o.MapFrom(x => x.Fax));
        }
    }
}
