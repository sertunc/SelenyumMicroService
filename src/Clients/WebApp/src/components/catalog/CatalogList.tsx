import { useState, useEffect } from "react";
import axios from "axios";
import { useParams, useSearchParams } from "react-router-dom";
import { Divider, Grid, Stack, Pagination } from "@mui/material";
import { CatalogListModel } from "../../models/CatalogListModel";
import CatalogListItem from "./CatalogListItem";
import CommonStyles from "../../CommonStyles";

export default function CatalogList() {
  const { id } = useParams();

  const [searchParams, setSearchParams] = useSearchParams();
  const [model, setModel] = useState<CatalogListModel>({
    count: 0,
    data: [],
    pageIndex: 0,
    pageSize: 5,
  });

  useEffect(() => {
    (async () => {
      const page = searchParams.get("page") || "1";

      if (id === undefined) {
        const response = await axios.get(`catalog/items?pageindex=${page}`);
        setModel(response.data.data);
      } else {
        const response2 = await axios.get(
          `catalog/itemsbytype?pageindex=${page}&catalogTypeId=${id}`
        );
        setModel(response2.data.data);
      }
    })();
  }, [id, searchParams]);

  const handleChange = (event: React.ChangeEvent<unknown>, page: number) => {
    setSearchParams({ page: page.toString() });
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
        <div style={CommonStyles.paginationContainer}>
          <Divider />
          <Stack spacing={2}>
            <Pagination
              color="secondary"
              showFirstButton
              showLastButton
              count={Math.ceil(model.count / model.pageSize)}
              page={model.pageIndex}
              onChange={handleChange}
            />
          </Stack>
        </div>
      )}
    </>
  );
}
