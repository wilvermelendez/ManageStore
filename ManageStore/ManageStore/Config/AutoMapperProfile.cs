﻿using AutoMapper;
using ManageStore.Models.DTO;
using ManageStore.Models.Models;

namespace ManageStore.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CreatedBy,
                    opt => opt.MapFrom(
                        src => $"{src.CreatedBy.Name} {src.CreatedBy.LastName}"))
                .ForMember(dest => dest.ModifiedBy,
                    opt => opt.MapFrom(
                        src => $"{src.ModifiedBy.Name} {src.ModifiedBy.LastName}"));
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductLog>();
            CreateMap<ProductLikeDto, ProductLike>();
            CreateMap<UserDto, User>();

        }
    }
}
