import { TextField } from "@material-ui/core";
import { IInput } from "../../../models/Interfaces/IContols";

export default function Input({
  id,
  name,
  label,
  value,
  error = null,
  onChange,
  variant,
  multiline = false,
  InputProps,
}: IInput) {
  return (
    <TextField
      id={id}
      label={label}
      name={name}
      value={value}
      fullWidth
      multiline={multiline}
      minRows={multiline ? 4 : 1}
      variant={variant}
      onChange={onChange}
      margin="dense"
      InputProps={InputProps}
      {...(error && { error: true, helperText: error })}
    />
  );
}
