﻿using AutoMapper;
using CatalogService.Business.Abstractions.Models;
using CatalogService.Data.Abstractions.Entities;

namespace CatalogService.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogTypesViewModel, CatalogType>()
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(x => x.Type, opts => opts.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<CatalogBrandsViewModel, CatalogBrand>()
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(x => x.Brand, opts => opts.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<CatalogItemViewModel, CatalogItem>()
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opts => opts.MapFrom(x => x.Name))
                .ForMember(x => x.Price, opts => opts.MapFrom(x => x.Price))
                .ReverseMap();

            CreateMap<CatalogListViewModel, CatalogItem>()
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opts => opts.MapFrom(x => x.Name))
                .ReverseMap();
        }
    }
}