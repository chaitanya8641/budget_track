import TextField from "@material-ui/core/TextField";
import Autocomplete from "@material-ui/lab/Autocomplete";
import FormHelperText from "@material-ui/core/FormHelperText";
import FormControl from "@material-ui/core/FormControl";
import { createStyles, makeStyles, Theme } from "@material-ui/core/styles";
import { ISelectAutoComplete } from "../../../models/Interfaces/IContols";

export default function AutoComplete({
  id,
  value,
  name,
  label,
  error = null,
  options,
  onChange,
  varient,
}: ISelectAutoComplete) {
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
      <Autocomplete
        disableClearable
        autoHighlight
        freeSolo
        defaultValue={value}
        id={id}
        onChange={(event, selectObj) => {
          onChange(event, selectObj, name);
        }}
        onInputChange={(event, newInputValue) => {
          if (newInputValue === "") {
            onChange(event, "", name);
          }
        }}
        options={options}
        getOptionLabel={(option) => option.label || ""}
        renderInput={(params: any) => (
          <TextField
            value={value}
            disabled
            {...params}
            label={label}
            margin="normal"
            size="small"
            name={name}
            InputProps={{ ...params.InputProps, type: "search" }}
            varient={varient}
          />
        )}
      />
      {error && <FormHelperText>{error}</FormHelperText>}
    </FormControl>
  );
}
