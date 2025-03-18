using AutoMapper;
using server.DTOs;
using server.Models;

namespace server.Data.Mapping.Profiles;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<Payment, PaymentDto>();
        CreateMap<CreatePaymentDto, Payment>();
    }
}