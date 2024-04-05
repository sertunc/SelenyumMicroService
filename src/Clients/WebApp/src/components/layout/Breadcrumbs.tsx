import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import Breadcrumbs from "@mui/material/Breadcrumbs";
import { Link } from "react-router-dom";
import { BreadcrumbItemModel } from "../../models/BreadcrumbItemModel";
import { getCatalogInfo, getCategoryInfo } from "./BreadcrumbUtils";
import CommonStyles from "../../CommonStyles";

export default function IconBreadcrumbs() {
  const location = useLocation();

  const [items, setItems] = useState<BreadcrumbItemModel[]>([
    {
      label: "Home",
      link: "/",
    },
  ]);

  useEffect(() => {
    determinePage(location.pathname);
  }, [location]);

  const determinePage = (pathname: string) => {
    const items = [
      {
        label: "Home",
        link: "/",
      },
    ];

    if (pathname.startsWith("/catalogdetail")) {
      const catalogId = pathname.split("/")[2];
      const catalog = getCatalogInfo(catalogId);

      if (catalog) {
        catalog.Categories.forEach((category) => {
          items.push({
            label: category.Name,
            link: category.Link,
          });
        });

        items.push({
          label: catalog.Name,
          link: "#",
        });
      }
    } else if (pathname.startsWith("/catalog")) {
      const categoryId = pathname.split("/")[2];
      const category = getCategoryInfo(categoryId);

      if (category) {
        items.push({
          label: category.Name,
          link: "#",
        });
      }
    }

    setItems(items);
  };

  return (
    <>
      <h3 />
      <Breadcrumbs aria-label="breadcrumb">
        {items.map((item, index) => (
          <Link key={index} style={CommonStyles.link} to={item.link}>
            {item.label}
          </Link>
        ))}
      </Breadcrumbs>
    </>
  );
}
