import React from "react";
import {
  FormControl,
  FormControlLabel,
  Checkbox as MuiCheckbox,
} from "@material-ui/core";
import { ICheckBox } from "../../../models/Interfaces/IContols";

export default function CheckBox({
  id,
  name,
  label,
  checked,
  value,
  onChange,
}: ICheckBox) {
  const convertToDefEventPara = (
    inputName: any,
    inputValue: any,
    isChecked: any,
  ) => {
    onChange({
      target: { name: inputName, value: inputValue, checked: isChecked },
    });
  };

  return (
    <FormControl>
      <FormControlLabel
        control={
          <MuiCheckbox
            id={id}
            name={name}
            value={value}
            color="primary"
            checked={checked}
            onChange={(e) => {
              convertToDefEventPara(name, e.target.checked, checked);
            }}
          />
        }
        label={label}
      />
    </FormControl>
  );
}
