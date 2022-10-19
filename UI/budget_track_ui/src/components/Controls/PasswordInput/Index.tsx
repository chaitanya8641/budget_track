import React from "react";
import { TextField } from "@material-ui/core";

export default function PasswordInput({
  id,
  name,
  label,
  value,
  error = null,
  onChange,
  variant,
}: any) {
  return (
    <TextField
      id={id}
      name={name}
      label={label}
      value={value}
      variant={variant || "standard"}
      type="password"
      onChange={onChange}
      fullWidth
      margin="dense"
      {...(error && { error: true, helperText: error })}
    />
  );
}
