import { BrowserRouter } from "react-router-dom";
import Layout from "./components/Layout";
import AxiosProvider from "./components/core/AxiosProvider";

function App(props: any) {
  console.log("App rendered");
  return (
    <AxiosProvider {...props}>
      <BrowserRouter>
        <Layout></Layout>
      </BrowserRouter>
    </AxiosProvider>
  );
}

export default App;
