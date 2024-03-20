﻿using AutoMapper;
using PalReviewApi.Dto;
using PalReviewApi.Models;

namespace PalReviewApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pal, PalDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
        }
    }
}
