import { useState } from "react";
import {
  MuiPickersUtilsProvider,
  KeyboardDatePicker,
} from "@material-ui/pickers";
import DateFnsUtils from "@date-io/date-fns";
import { IDatePicker } from "../../../models/Interfaces/IContols";

const DatePicker = (datePickers: IDatePicker) => {
  const [selectedDate, handleDateChange] = useState<Date>(new Date());
  const {
    id,
    name,
    variant,
    inputVariant,
    orientation,
    label,
    placeholder,
    format,
  } = datePickers;

  return (
    <MuiPickersUtilsProvider utils={DateFnsUtils}>
      <KeyboardDatePicker
        autoOk
        id={id}
        name={name}
        variant={variant}
        value={selectedDate}
        inputVariant={inputVariant}
        label={label}
        placeholder={placeholder}
        format={format}
        orientation={orientation}
        onChange={(newDate: any) => {
          handleDateChange(newDate);
        }}
      />
    </MuiPickersUtilsProvider>
  );
};

export default DatePicker;
