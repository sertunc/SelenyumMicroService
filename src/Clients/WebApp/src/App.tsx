import { BrowserRouter, Route, Routes } from "react-router-dom";
import Error from "./components/layout/Error";
import Layout from "./components/layout/Layout";
import AxiosProvider from "./components/core/AxiosProvider";
import CatalogList from "./components/CatalogList";
import CatalogDetail from "./components/CatalogDetail";
import CatalogDetailNotFound from "./components/CatalogDetailNotFound";

function App(props: any) {
  console.log("App rendered");
  return (
    <AxiosProvider {...props}>
      <BrowserRouter>
        <Layout>
          <Routes>
            <Route
              path="/"
              element={<CatalogList />}
              errorElement={<Error />}
            />
            <Route
              path="catalog/:id"
              element={<CatalogList />}
              errorElement={<Error />}
            />
            <Route
              path="catalogdetail/:id"
              element={<CatalogDetail />}
              errorElement={<Error />}
            />
            <Route
              path="catalogdetailnotfound"
              element={<CatalogDetailNotFound />}
              errorElement={<Error />}
            />
          </Routes>
        </Layout>
      </BrowserRouter>
    </AxiosProvider>
  );
}

export default App;
