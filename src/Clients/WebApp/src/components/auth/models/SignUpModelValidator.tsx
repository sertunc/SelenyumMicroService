import { FormikErrors } from "formik";
import { SignUpModel } from "./SignUpModel";

export const signUpModelValidator = (
  values: SignUpModel
): FormikErrors<SignUpModel> => {
  const errors: FormikErrors<SignUpModel> = {};

  if (!values.name) {
    errors.name = "First Name is required";
  }

  if (!values.surname) {
    errors.surname = "Last Name is required";
  }

  if (!values.username) {
    errors.username = "Username is required";
  }

  if (!values.email) {
    errors.email = "Email is required";
  }

  if (!values.password) {
    errors.password = "Password is required";
  }

  if (!values.confirmPassword) {
    errors.confirmPassword = "Confirm Password is required";
  }

  return errors;
};
