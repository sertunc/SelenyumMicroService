import { SnackbarProvider } from "./contexts/SnackbarContext";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Error from "./components/layout/Error";
import Layout from "./components/layout/Layout";
import AxiosProvider from "./components/core/AxiosProvider";
import SignIn from "./components/auth/SignIn";
import SignUp from "./components/auth/SignUp";
import CatalogList from "./components/CatalogList";
import CatalogDetail from "./components/CatalogDetail";
import CatalogDetailNotFound from "./components/CatalogDetailNotFound";

function App(props: any) {
  return (
    <SnackbarProvider>
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
                path="/signin"
                element={<SignIn />}
                errorElement={<Error />}
              />
              <Route
                path="/signup"
                element={<SignUp />}
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
    </SnackbarProvider>
  );
}

export default App;
