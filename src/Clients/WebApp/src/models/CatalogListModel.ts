export class CatalogListModel {
  count: number;
  data: CatalogListViewModel[];
  pageIndex: number;
  pageSize: number;
}

export class CatalogListViewModel {
  id: string;
  name: string;
  description: string;
  pictureUri: string;
  price: number;
}
