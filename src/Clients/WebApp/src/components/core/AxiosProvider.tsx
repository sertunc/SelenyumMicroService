import React, { useState } from "react";
import axios from "axios";
import { v4 as uuidv4 } from "uuid";
import { CircularProgress, Dialog, DialogContent } from "@mui/material";

export default function AxiosProvider(props: any) {
  const [showInprogress, setInprogressCount] = useState(false);
  //const { enqueueSnackbar } = useSnackbar();

  const bearerTokenKey = "Bearer";
  const requestIdKey = "X-Request-Id";
  axios.defaults.baseURL = import.meta.env.VITE_GATEWAY_BASEURL;

  // Add a request interceptor
  axios.interceptors.request.use(
    (config) => {
      //   if (token) {
      //     config.headers.Authorization = `${bearerTokenKey} ${token}`;
      //   }

      config.headers[requestIdKey] = uuidv4();

      return config;
    },
    (error) => {
      setInprogressCount(false);

      //showSnackbar(`${Messages.errorOccured}${error}`, enqueueSnackbar);

      return Promise.reject(error);
    }
  );

  // Add a response interceptor
  axios.interceptors.response.use(
    (response: any) => {
      setInprogressCount(false);

      return response;
    },
    (error) => {
      setInprogressCount(false);

      //showResponseError(error, enqueueSnackbar);

      return Promise.reject(error);
    }
  );

  return (
    <React.Fragment>
      {React.Children.only(props.children)}
      <Dialog open={showInprogress}>
        <DialogContent>
          <CircularProgress />
        </DialogContent>
      </Dialog>
    </React.Fragment>
  );
}
