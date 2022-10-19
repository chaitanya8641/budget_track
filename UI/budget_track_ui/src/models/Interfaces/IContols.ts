import {  SyntheticEvent } from "react";

export interface IButtonProp {
  id?: string;
  text?: string;
  disabled?: boolean;
  type?: "button" | "reset" | "submit" | undefined;
  size?: "small" | "medium" | "large";
  color?: "inherit" | "default" | "primary" | "secondary" | undefined;
  variant?: "text" | "contained";
  onClick?: (() => void) | ((e: SyntheticEvent) => void);
}

export interface ItargetCheckbox {}
export interface ICheckBox {
  id?: string;
  name?: string;
  label?: string;
  value?: boolean | undefined;
  checked?: boolean | undefined;
  onChange: (target: any) => void | undefined;
  error?: any;
}

export interface ItargetDatePicker {
  name: string;
  value: string;
}

export interface IDatePicker {
  id?: string;
  name?: string;
  label?: string;
  value: Date;
  onChange: (date: Date, e: any) => void;
  variant: "dialog" | "inline" | "static";
  inputVariant: "standard" | "outlined" | "filled";
  format: "dd/MM/yyyy";
  placeholder: "dd/MM/yyyy";
  orientation?: "portrait" | "landscape";
}

export interface IInput {
  id?: string;
  name: string;
  label?: string;
  value?: string;
  cName?: string;
  onChange?: (e: any) => void | undefined;
  variant?: "outlined" | "filled" | "standard";
  error?: any;
  type?: string;
  multiline?: boolean;
  rows?: number;
  InputProps?: {};
}

export interface ISelect {
  id: string;
  name: string;
  label: string;
  value?: string;
  error?: any;
  onChange: (e: any) => void;
  options: ISelectOptions[];
  variant?: "outlined";
  disabled?: boolean;
}

export interface IMultiSelect {
  id: string;
  name: string;
  label: string;
  value?: [];
  error?: any;
  onChange: (e: any) => void;
  options?: any;
}

export interface ISelectOptions {
  key: string;
  label: string;
}

export interface IAutoComplete {
  value: string;
  onSelect: (e: any) => void;
  setParentAddressAndCoordinates: (x: string, y: any) => void;
  varient?: "standard" | "outlined" | "filled";
}

export interface ISelectAutoComplete {
  id: string;
  name: string;
  label?: string;
  value?: string;
  error?: any;
  onChange?: any;
  options: ISelectOptions[];
  varient?: "standard" | "outlined" | "filled";
}
