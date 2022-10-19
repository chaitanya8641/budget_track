import React from "react";
import MuiRating from "@mui/material/Rating";

type RatingProps = {
  value: number | null;
  name?: string;
  disabled?: boolean;
  readOnly?: boolean;
  onChange?: (event: React.ChangeEvent<{}>, value: number | null) => void;
};

export const Rating = (props: RatingProps) => {
  const {
    value,
    name = "",
    disabled = false,
    readOnly = false,
    onChange,
  } = props;
  return (
    <MuiRating
      name={name}
      value={value}
      disabled={disabled}
      onChange={onChange}
      readOnly={readOnly}
    />
  );
};
