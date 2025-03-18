using AutoMapper;
using server.DTOs;
using server.Models;

namespace server.Data.Mapping.Profiles;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<CreateCarDto, Car>();
    }
}