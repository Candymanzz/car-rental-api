using AutoMapper;
using server.DTOs;
using server.Models;

namespace server.Data.Mapping.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<Review, ReviewDto>();
        CreateMap<CreateReviewDto, Review>();
    }
}