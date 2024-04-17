import axios from "axios";
import { useFormik } from "formik";
import { useNavigate } from "react-router-dom";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { SignUpModel } from "./models/SignUpModel";
import { signUpModelValidator } from "./models/SignUpModelValidator";
import FormikTextField from "../common/FormikTextField";
import { useSnackbar } from "../../contexts/SnackbarContext";

export default function SignUp() {
  const navigate = useNavigate();
  const { openSnackbar } = useSnackbar();

  const formik = useFormik({
    initialValues: new SignUpModel(),
    validate: signUpModelValidator,
    onSubmit: (values, actions) => {
      axios.post("auth/signup", values).then((response) => {
        if (response.data.data === true) {
          actions.resetForm({ values: new SignUpModel() });
          openSnackbar(response.data.message, "success");
          navigate("/signin");
        } else {
          //TODO: move to axios provider
          let errorMessageList = "";

          response.data.errors.forEach((element: string) => {
            errorMessageList += element + "\n";
          });

          openSnackbar(errorMessageList, "error");
        }
      });
    },
  });

  const handleClick = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    navigate("/signin");
  };

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <Box
        sx={{
          marginTop: 8,
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign up
        </Typography>
        <Box component="form" onSubmit={formik.handleSubmit} sx={{ mt: 3 }}>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6}>
              <FormikTextField
                label="First Name"
                type="text"
                fieldName="name"
                formik={formik}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <FormikTextField
                label="Last Name"
                type="text"
                fieldName="surname"
                formik={formik}
              />
            </Grid>
            <Grid item xs={12}>
              <FormikTextField
                label="User Name"
                type="text"
                fieldName="username"
                formik={formik}
              />
            </Grid>
            <Grid item xs={12}>
              <FormikTextField
                label="E-Mail"
                type="text"
                fieldName="email"
                formik={formik}
              />
            </Grid>
            <Grid item xs={12}>
              <FormikTextField
                label="Password"
                type="password"
                fieldName="password"
                formik={formik}
              />
            </Grid>
            <Grid item xs={12}>
              <FormikTextField
                label="Confirm Password"
                type="password"
                fieldName="confirmPassword"
                formik={formik}
              />
            </Grid>
          </Grid>
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Sign Up
          </Button>
          <Grid container justifyContent="flex-end">
            <Grid item>
              <Link href="" variant="body2" onClick={handleClick}>
                Already have an account? Sign in
              </Link>
            </Grid>
          </Grid>
        </Box>
      </Box>
    </Container>
  );
}
