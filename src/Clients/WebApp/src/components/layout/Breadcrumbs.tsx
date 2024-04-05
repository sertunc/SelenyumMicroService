import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import Breadcrumbs from "@mui/material/Breadcrumbs";
import { Link } from "react-router-dom";
import { BreadcrumbItemModel } from "../../models/BreadcrumbItemModel";
import { getCatalogInfo, getCatalogCategory } from "./BreadcrumbUtils";
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
    console.log(location.pathname);
    determinePage(location.pathname);
  }, [location]);

  const determinePage = (pathname: string) => {
    const items = [
      {
        label: "Home",
        link: "/",
      },
    ];

    switch (true) {
      case pathname.startsWith("/catalogdetail"):
        const detailId = pathname.split("/")[2];
        const detailCatalogInfo = getCatalogInfo(detailId);

        items.push({
          label: detailCatalogInfo[0],
          link: "#",
        });

        items.push({
          label: detailCatalogInfo[1],
          link: "#",
        });
        break;
      case pathname.startsWith("/catalog"):
        const catalogId = pathname.split("/")[2];
        items.push({
          label: getCatalogCategory(catalogId),
          link: "#",
        });
        break;
      default:
        console.log("Bu farklı bir sayfadır.");
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
