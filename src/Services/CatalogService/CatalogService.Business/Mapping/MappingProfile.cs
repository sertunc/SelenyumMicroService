using AutoMapper;
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
                .ForMember(x => x.IconName, opts => opts.MapFrom(x => x.IconName))
                .ReverseMap();

            CreateMap<CatalogItem, CatalogItemViewModel>()
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opts => opts.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opts => opts.MapFrom(x => x.Description))
                .ForMember(x => x.Price, opts => opts.MapFrom(x => x.Price))
                .ForMember(x => x.PictureUri, opts => opts.MapFrom(x => x.PictureUri))
                .ForMember(x => x.CatalogType, opt => opt.MapFrom(x => x.CatalogType.Type))
                .ReverseMap();

            CreateMap<CatalogListViewModel, CatalogItem>().ReverseMap();
        }
    }
}