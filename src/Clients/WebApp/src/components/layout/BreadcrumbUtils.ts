interface Category {
  Order: string;
  Id: string;
  Name: string;
  Link: string;
}

interface CatalogItem {
  Id: string;
  Name: string;
  Categories: Category[];
}

const categories: Category[] = [
  {
    Order: "",
    Id: "1",
    Name: "Mug",
    Link: "/catalog/1",
  },
  {
    Order: "",
    Id: "2",
    Name: "T-Shirt",
    Link: "/catalog/2",
  },
  {
    Order: "",
    Id: "3",
    Name: "Sheet",
    Link: "/catalog/3",
  },
  {
    Order: "",
    Id: "4",
    Name: "USB Memory Stick",
    Link: "/catalog/4",
  },
];

export const getCategoryInfo = (id: string): Category | null => {
  const category = categories.find((cat) => cat.Id === id);
  return category ? category : null;
};

const catalogs: CatalogItem[] = [
  {
    Id: "1",
    Name: "Self Stirring Coffee Mug",
    Categories: [
      {
        Order: "1",
        Id: "1",
        Name: "Mug",
        Link: "/catalog/1",
      },
    ],
  },
  {
    Id: "2",
    Name: "Aardman Wallace Mug",
    Categories: [
      {
        Order: "1",
        Id: "1",
        Name: "Mug",
        Link: "/catalog/1",
      },
    ],
  },
  {
    Id: "5",
    Name: "Gildan Men's Crew T-Shirts",
    Categories: [
      {
        Order: "1",
        Id: "2",
        Name: "T-Shirt",
        Link: "/catalog/2",
      },
    ],
  },
  {
    Id: "8",
    Name: "Microfiber 4-Piece Bed Sheet",
    Categories: [
      {
        Order: "1",
        Id: "3",
        Name: "Sheet",
        Link: "/catalog/3",
      },
    ],
  },
];

export const getCatalogInfo = (catalogId: string): CatalogItem | null => {
  const catalogItem = catalogs.find((item) => item.Id === catalogId);
  if (catalogItem) {
    catalogItem.Categories.sort(
      (a, b) => parseInt(a.Order) - parseInt(b.Order)
    );
    return catalogItem;
  } else {
    return null;
  }
};
