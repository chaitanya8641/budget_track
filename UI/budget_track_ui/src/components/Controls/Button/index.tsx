import React from "react";
import { Button as MuiButton, makeStyles } from "@material-ui/core";
import { IButtonProp } from "../../../models/Interfaces/IContols";

const useStyles = makeStyles((theme) => ({
  root: {
    margin: theme.spacing(0.5),
  },
  label: {
    textTransform: "none",
  },
}));

export default function Button({
  id,
  text,
  size,
  color,
  variant,
  onClick,
  disabled,
  ...other
}: IButtonProp) {
  const classes = useStyles();

  return (
    <MuiButton
      classes={{ root: classes.root, label: classes.label }}
      id={id}
      variant={variant || "contained"}
      size={size || "large"}
      color={color || "primary"}
      onClick={onClick}
      disabled={disabled}
      {...other}
    >
      {text}
    </MuiButton>
  );
}
