import { useState, useEffect } from "react";
import axios from "axios";
import { useUser } from "../../contexts/UserContext";
import { Typography, Container, Grid } from "@mui/material";

export default function UserProfile() {
  const { user } = useUser();
  const [model, setModel] = useState({});

  useEffect(() => {
    (async () => {
      //TODO: centeralize token
      const headers = { Authorization: "Bearer " + user?.token };
      const response = await axios.get("auth/userprofile", { headers });
      setModel(response.data.data);
    })();
  }, [user]);

  return (
    <Grid container>
      <Grid item>
        <Typography variant="h5">
          {model.name} {model.surname}
        </Typography>
        <Typography variant="body1" color="textSecondary">
          {model.email}
        </Typography>
      </Grid>
    </Grid>
  );
}
