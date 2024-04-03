using AutoMapper;
using CatalogService.Business.Abstractions.Interfaces;
using CatalogService.Business.Abstractions.Models;
using CatalogService.Data.Abstractions.Interfaces;
using SelenyumMicroService.Shared.Dtos;
using System.Net;

namespace CatalogService.Business.Business
{
    public class CatalogBusiness : ICatalogBusiness
    {
        private readonly IMapper _mapper;
        private readonly ICatalogRepository _catalogRepository;

        public CatalogBusiness(
            IMapper mapper,
            ICatalogRepository catalogRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _catalogRepository = catalogRepository ?? throw new ArgumentNullException(nameof(catalogRepository));
        }

        public async Task<Response<IEnumerable<CatalogTypesViewModel>>> GetCatalogTypesAsync()
        {
            var catalogTypes = await _catalogRepository.GetCatalogTypesAsync();

            var result = _mapper.Map<IEnumerable<CatalogTypesViewModel>>(catalogTypes);

            return Response<IEnumerable<CatalogTypesViewModel>>.Success(result);
        }

        public async Task<Response<CatalogItemViewModel>> GetCatalogItemAsync(int id)
        {
            var catalogItem = await _catalogRepository.GetCatalogItemAsync(id);

            if (catalogItem == null)
            {
                return Response<CatalogItemViewModel>.Fail("Catalog item not found.", (int)HttpStatusCode.NotFound);
            }

            var item = _mapper.Map<CatalogItemViewModel>(catalogItem);
            return Response<CatalogItemViewModel>.Success(item);
        }

        public async Task<Response<PaginatedItemsViewModel<CatalogListViewModel>>> GetCatalogItemsAsync(int pageSize, int pageIndex)
        {
            var totalItems = await _catalogRepository.GetCatalogItemsTotalAsync();
            var itemsOnPage = await _catalogRepository.GetCatalogItemsAsync(pageSize, pageIndex);

            //TODO: Currency type should be kept for each product in the database
            //TODO: Return currency based on user's region or choice
            var items = _mapper.Map<IEnumerable<CatalogListViewModel>>(itemsOnPage);

            var result = new PaginatedItemsViewModel<CatalogListViewModel>(pageIndex, pageSize, totalItems, items);

            return Response<PaginatedItemsViewModel<CatalogListViewModel>>.Success(result);
        }
    }
}