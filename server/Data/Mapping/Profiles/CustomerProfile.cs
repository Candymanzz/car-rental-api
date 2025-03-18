using AutoMapper;
using server.DTOs;
using server.Models;

namespace server.Data.Mapping.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));

        CreateMap<CreateCustomerDto, Customer>();
    }
}