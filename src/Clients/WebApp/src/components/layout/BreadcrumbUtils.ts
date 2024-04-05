type CatalogInfo = [string, string];

export const getCatalogCategory = (id: string) => {
  switch (id) {
    case "1":
      return "Mug";
    case "2":
      return "T-Shirt";
    case "3":
      return "Sheet";
    case "4":
      return "USB Memory Stick";
    default:
      return "Home";
  }
};

export const getCatalogInfo = (catalogId: string): CatalogInfo => {
  switch (catalogId) {
    case "1":
      return ["Mug", "Self Stirring Coffee Mug"];
    case "2":
      return ["Mug", "Aardman Wallace Mug"];
    case "5":
      return ["T-Shirt", "Gildan Men's Crew T-Shirts"];
    case "8":
      return ["Sheet", "Microfiber 4-Piece Bed Sheet"];
    default:
      return ["Home", "Home"];
  }
};
