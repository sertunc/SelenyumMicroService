import { useState, useEffect } from "react";
import axios from "axios";
import { Divider, Grid, Stack, Pagination } from "@mui/material";
import { CatalogListModel } from "../models/CatalogListModel";
import CatalogListItem from "./CatalogListItem";

export default function CatalogList() {
  const [model, setModel] = useState<CatalogListModel>({
    count: 0,
    data: [],
    pageIndex: 0,
    pageSize: 5,
  });

  useEffect(() => {
    (async () => {
      const response = await axios.get(
        `catalog/items?pagesize=${model.pageSize}&pageindex=${model.pageIndex}`
      );
      setModel(response.data.data);
    })();
  }, [model.pageIndex]);

  const handleChange = (event: React.ChangeEvent<unknown>, page: number) => {
    setModel({
      ...model,
      pageIndex: page - 1,
    });
    console.log(page);
  };

  return (
    <>
      <Grid container spacing={2}>
        {model.data?.map((item) => (
          <Grid key={item.id} item xs={12} sm={6} md={6} lg={4} xl={2}>
            <CatalogListItem key={item.id} item={item} />
          </Grid>
        ))}
      </Grid>

      {model.data?.length > 0 && (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            marginTop: 20,
            marginBottom: 20,
          }}
        >
          <Divider />
          <Stack spacing={2}>
            <Pagination
              color="secondary"
              showFirstButton
              showLastButton
              count={model.count}
              page={model.pageIndex + 1}
              onChange={handleChange}
            />
          </Stack>
        </div>
      )}
    </>
  );
}
