import {
  FormControl,
  InputLabel,
  Select as MuiSelect,
  MenuItem,
  FormHelperText,
} from "@material-ui/core";
import { IMultiSelect } from "../../../models/Interfaces/IContols";

export default function MultiSelect({
  id,
  name,
  label,
  value,
  error = null,
  onChange,
  options,
}: IMultiSelect) {
  return (
    <FormControl variant="standard" {...(error && { error: true })}>
      <InputLabel>{label}</InputLabel>
      <MuiSelect
        MenuProps={{ autoFocus: false }}
        id={id}
        label={label}
        name={name}
        value={value}
        onChange={onChange}
        multiple
      >
        {options.map((item: any) => (
          <MenuItem key={item.key} value={item.key}>
            {item.label}
          </MenuItem>
        ))}
      </MuiSelect>
      {error && <FormHelperText>{error}</FormHelperText>}
    </FormControl>
  );
}
