using AutoMapper;
using PalReviewApi.Dto;
using PalReviewApi.Models;

namespace PalReviewApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pal, PalDto>();
            CreateMap<PalDto, Pal>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();
        }
    }
}
