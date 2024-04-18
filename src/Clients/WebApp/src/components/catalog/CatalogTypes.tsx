import { useState, useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";
import {
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";
import { CatalogTypeModel } from "../../models/CatalogTypeModel";
import CommonStyles from "../../CommonStyles";

import HomeIcon from "@mui/icons-material/Home";
import CoffeeIcon from "@mui/icons-material/Coffee";
import ImageIcon from "@mui/icons-material/Image";
import NoteIcon from "@mui/icons-material/Note";
import SdCardIcon from "@mui/icons-material/SdCard";

export default function CatalogTypes() {
  const [menuId, setMenuId] = useState(0);
  const [model, setModel] = useState<CatalogTypeModel[]>([]);

  const handleMenuClick = (menuId: number) => {
    setMenuId(menuId);
  };

  useEffect(() => {
    (async () => {
      const response = await axios.get("catalog/types");
      setModel(response.data.data);
    })();
  }, []);

  return (
    <List component="nav">
      <Link style={CommonStyles.link} key={0} to={"/"}>
        <ListItemButton
          key={0}
          selected={menuId === 0}
          onClick={() => handleMenuClick(0)}
        >
          <ListItemIcon>
            <HomeIcon />
          </ListItemIcon>
          <ListItemText primary={"Home"} />
        </ListItemButton>
      </Link>
      {model.map((item) => (
        <Link
          style={CommonStyles.link}
          key={item.id}
          to={`/catalog/${item.id}`}
        >
          <ListItemButton
            key={item.id}
            selected={menuId === item.id}
            onClick={() => handleMenuClick(item.id)}
          >
            <ListItemIcon>
              <MenuIcon name={item.iconName} />
            </ListItemIcon>
            <ListItemText primary={item.name} />
          </ListItemButton>
        </Link>
      ))}
    </List>
  );
}

interface MenuIconProps {
  name: string;
}

const MenuIcon: React.FC<MenuIconProps> = ({ name }) => {
  switch (name) {
    case "CoffeeIcon":
      return <CoffeeIcon />;
    case "ImageIcon":
      return <ImageIcon />;
    case "NoteIcon":
      return <NoteIcon />;
    case "SdCardIcon":
      return <SdCardIcon />;
    default:
      return null;
  }
};
