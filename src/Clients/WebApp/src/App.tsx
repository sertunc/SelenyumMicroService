import { SnackbarProvider } from "./contexts/SnackbarContext";
import { UserProvider } from "./contexts/UserContext";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Error from "./components/layout/Error";
import Layout from "./components/layout/Layout";
import AxiosProvider from "./components/core/AxiosProvider";
import SignIn from "./components/auth/SignIn";
import SignUp from "./components/auth/SignUp";
import UserProfile from "./components/user/UserProfile";
import CatalogList from "./components/catalog/CatalogList";
import CatalogDetail from "./components/catalog/CatalogDetail";
import CatalogDetailNotFound from "./components/catalog/CatalogDetailNotFound";

function App(props: any) {
  return (
    <SnackbarProvider>
      <UserProvider>
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
                  path="/userprofile"
                  element={<UserProfile />}
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
      </UserProvider>
    </SnackbarProvider>
  );
}

export default App;
