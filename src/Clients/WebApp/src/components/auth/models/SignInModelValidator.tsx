import { FormikErrors } from "formik";
import { SignInModel } from "./SignInModel";

export const signInModelValidator = (
  values: SignInModel
): FormikErrors<SignInModel> => {
  const errors: FormikErrors<SignInModel> = {};

  if (!values.username) {
    errors.username = "Username is required";
  }

  if (!values.password) {
    errors.password = "Password is required";
  }

  return errors;
};
