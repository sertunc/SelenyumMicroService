import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import CommonStyles from "../../CommonStyles";
import Breadcrumbs from "@mui/material/Breadcrumbs";
import { Link } from "react-router-dom";
import { BreadcrumbItemModel } from "../../models/BreadcrumbItemModel";

type CatalogInfo = [string, string];

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

  //TODO: maybe we can get from graphdb
  const getCatalogCategory = (id: string) => {
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

  //TODO: maybe we can get from graphdb
  const getCatalogInfo = (catologId: string): CatalogInfo => {
    switch (catologId) {
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
