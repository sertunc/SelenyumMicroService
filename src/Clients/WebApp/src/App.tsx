import { BrowserRouter, Route, Routes } from "react-router-dom";
import Layout from "./components/layout/Layout";
import AxiosProvider from "./components/core/AxiosProvider";
import CatalogList from "./components/CatalogList";
import CatalogDetail from "./components/CatalogDetail";

function App(props: any) {
  console.log("App rendered");
  return (
    <AxiosProvider {...props}>
      <BrowserRouter>
        <Layout>
          <Routes>
            <Route path="/" element={<CatalogList />} />
            <Route path="catalogdetail/:id" element={<CatalogDetail />} />
          </Routes>
        </Layout>
      </BrowserRouter>
    </AxiosProvider>
  );
}

export default App;
