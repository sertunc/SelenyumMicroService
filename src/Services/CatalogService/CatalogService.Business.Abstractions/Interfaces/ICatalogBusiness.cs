﻿using CatalogService.Business.Abstractions.Models;
using SelenyumMicroService.Shared.Dtos;

namespace CatalogService.Business.Abstractions.Interfaces
{
    public interface ICatalogBusiness
    {
        Task<Response<IEnumerable<CatalogTypesViewModel>>> GetCatalogTypesAsync();

        Task<Response<PaginatedItemsViewModel<CatalogListViewModel>>> GetCatalogItemByCatalogTypeAsync(int catalogTypeId, int pageSize, int pageIndex);

        Task<Response<CatalogItemViewModel>> GetCatalogItemAsync(int id);

        Task<Response<PaginatedItemsViewModel<CatalogListViewModel>>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    }
}