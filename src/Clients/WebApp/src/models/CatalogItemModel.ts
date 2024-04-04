export class CatalogItemModel {
  count: number;
  data: CatalogItemViewModel;
  pageIndex: number;
  pageSize: number;
}

export class CatalogItemViewModel {
  id: string;
  name: string;
  description: string;
  pictureUri: string;
  price: number;
}
