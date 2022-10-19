import React from "react";
import InputLabel from "@material-ui/core/InputLabel";
import Select from "@material-ui/core/Select";
import MenuItem from "@material-ui/core/MenuItem";
import FormHelperText from "@material-ui/core/FormHelperText";
import FormControl from "@material-ui/core/FormControl";
import { createStyles, makeStyles, Theme } from "@material-ui/core/styles";
import "./Style.css";
// import { makeStyles } from "@material-ui/core/styles";
import { ISelect, ISelectOptions } from "../../../models/Interfaces/IContols";

export default function SelectField({
  id,
  name,
  label,
  value,
  error = null,
  onChange,
  options,
  disabled,
  variant,
}: ISelect) {
  const useStyles = makeStyles((theme: Theme) =>
    createStyles({
      formControl: {
        margin: theme.spacing(1),
        minWidth: 120,
        maxHeight: 70,
      },
      selectEmpty: {
        marginTop: theme.spacing(2),
      },
    }),
  );
  const classes = useStyles();
  return (
    <FormControl
      size="small"
      className={`${classes.formControl} Select-dropdown`}
      {...(error && { error: true })}
    >
      <InputLabel id="demo-simple-select-outlined-label">{label}</InputLabel>
      <Select
        labelId="demo-simple-select-outlined-label"
        id={id}
        name={name}
        value={value}
        onChange={onChange}
        variant={variant}
        label={label}
        disabled={disabled}
      >
        {options?.map((item: ISelectOptions) => (
          <MenuItem key={item.key} value={item.key}>
            {item.label}
          </MenuItem>
        ))}
      </Select>
      {error && <FormHelperText>{error}</FormHelperText>}
    </FormControl>
  );
}
