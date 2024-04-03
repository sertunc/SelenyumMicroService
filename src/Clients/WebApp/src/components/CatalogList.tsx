import { useState, useEffect } from "react";
import axios from "axios";
import { CatalogListViewModel } from "../models/CatalogListViewModel";
import CatalogListItem from "./CatalogListItem";
import { Grid } from "@mui/material";

export default function CatalogList() {
  const [model, setModel] = useState<CatalogListViewModel[]>([]);

  useEffect(() => {
    (async () => {
      const response = await axios.get("catalog/items?pagesize=10&pageindex=0");
      setModel(response.data.data.data);
    })();
  }, []);
  return (
    <Grid container spacing={2}>
      {model.map((item) => (
        <Grid item xs={12} sm={6} md={6} lg={4} xl={2}>
          <CatalogListItem key={item.id} item={item} />
        </Grid>
      ))}
    </Grid>
  );
}
