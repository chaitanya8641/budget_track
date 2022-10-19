import React, { useState } from "react";
import { makeStyles } from "@material-ui/core";

export function useForm(
  initialFValues?: any,
  validateOnChange = false,
  validate?: any,
) {
  const [values, setValues] = useState(initialFValues);
  const [errors, setErrors] = useState({});

  const handleInputChange = (e: any) => {
    const { name, value } = e.target as HTMLInputElement;
    const path = name.split(".");
    const depth = path.length;
    const state = { ...values };
    let ref = state;
    for (let i = 0; i < depth; i += 1) {
      if (i === depth - 1) {
        ref[path[i]] = value;
      } else {
        ref = ref[path[i]];
      }
    }

    setValues({ ...state });

    if (validateOnChange) validate({ [name]: value });
  };

  const handleRatingChange = (e: any) => {
    const { name, value } = e.target as HTMLInputElement;
    const path = name.split(".");
    const depth = path.length;
    const state = { ...values };
    let ref = state;
    for (let i = 0; i < depth; i += 1) {
      if (i === depth - 1) {
        ref[path[i]] = Number(value);
      } else {
        ref = ref[path[i]];
      }
    }
    setValues({ ...state });
    if (validateOnChange) validate({ [name]: value });
  };

  const setDataValues = (changedValues: any) => {
    setValues({ ...changedValues });
  };

  const resetForm = () => {
    setValues(initialFValues);
    setErrors({});
  };

  return {
    values,
    setValues,
    errors,
    setErrors,
    handleInputChange,
    handleRatingChange,
    resetForm,
    setDataValues,
  };
}

const useStyles = makeStyles(() => ({
  root: {
    "& .MuiFormControl-root": {
      width: "100%",
    },
  },
}));

export function Form(props: any) {
  const classes = useStyles();
  const { children, ...other } = props;
  return (
    <form className={classes.root} autoComplete="off" {...other}>
      {props.children}
    </form>
  );
}
