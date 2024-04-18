import axios from "axios";
import { useFormik } from "formik";
import { useNavigate } from "react-router-dom";
import { useUser } from "../../contexts/UserContext";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { useSnackbar } from "../../contexts/SnackbarContext";
import { SignInModel } from "./models/SignInModel";
import { signInModelValidator } from "./models/SignInModelValidator";
import { UserModel } from "../../models/UserModel";
import FormikTextField from "../common/FormikTextField";

export default function SignIn() {
  const navigate = useNavigate();
  const { openSnackbar } = useSnackbar();
  const { setUserInfo } = useUser();

  const formik = useFormik({
    initialValues: new SignInModel(),
    validate: signInModelValidator,
    onSubmit: (values, actions) => {
      axios.post("auth/login", values).then((response) => {
        if (response.data.isSuccessful === true) {
          const user = new UserModel(
            response.data.data.userName,
            response.data.data.token
          );

          localStorage.setItem("user", JSON.stringify(user));

          setUserInfo(user);

          actions.resetForm({ values: new SignInModel() });

          openSnackbar(response.data.message, "success");

          navigate("/");
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
    navigate("/signup");
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
          Sign in
        </Typography>
        <Box
          component="form"
          onSubmit={formik.handleSubmit}
          noValidate
          sx={{ mt: 1 }}
        >
          <FormikTextField
            margin="normal"
            label="Username"
            type="text"
            fieldName="username"
            formik={formik}
          />
          <FormikTextField
            margin="normal"
            label="Password"
            type="password"
            fieldName="password"
            formik={formik}
          />
          {/* <FormControlLabel
            control={<Checkbox value="remember" color="primary" />}
            label="Remember me"
          /> */}
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Sign In
          </Button>
          <Grid container>
            <Grid item xs>
              <Link href="#" variant="body2">
                Forgot password?
              </Link>
            </Grid>
            <Grid item>
              <Link href="" variant="body2" onClick={handleClick}>
                {"Don't have an account? Sign Up"}
              </Link>
            </Grid>
          </Grid>
        </Box>
      </Box>
    </Container>
  );
}
