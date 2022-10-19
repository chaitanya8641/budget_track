import React from "react";
import PlacesAutocomplete, {
  getLatLng,
  geocodeByAddress,
} from "react-places-autocomplete";
import { IAutoComplete } from "../../../models/Interfaces/IContols";
import "./Style.css";

export default function Address({
  value,
  setParentAddressAndCoordinates,
}: IAutoComplete) {
  const [address, setAddress] = React.useState(value);

  const handleSelect = async (x: any) => {
    const results = await geocodeByAddress(x);
    const latLng = await getLatLng(results[0]);
    setAddress(x);
    setParentAddressAndCoordinates(x, latLng);
  };

  return (
    <PlacesAutocomplete
      value={address}
      onChange={setAddress}
      onSelect={handleSelect}
    >
      {({ getInputProps, suggestions, getSuggestionItemProps, loading }) => (
        <>
          <div className="MuiInputBase-root MuiInput-root MuiInput-underline MuiInputBase-fullWidth MuiInput-fullWidth MuiInputBase-formControl MuiInput-formControl MuiInputBase-marginDense MuiInput-marginDense">
            <input
              {...getInputProps({ placeholder: "Type address here..." })}
              className="MuiInputBase-input MuiInput-input MuiInputBase-inputMarginDense MuiInput-inputMarginDense"
            />
          </div>
          <div className="MuiPaper-root MuiMenu-paper MuiPaper-elevation8 MuiPaper-rounded suggestions">
            {loading ? <div>Loading...</div> : null}
            {suggestions.map((suggestion) => {
              const style = {
                backgroundColor: suggestion.active ? "#f5f5f5" : "#fff",
                margin: "0.5em",
                cursor: "pointer",
              };

              return (
                <div {...getSuggestionItemProps(suggestion, { style })}>
                  {suggestion.description}
                </div>
              );
            })}
          </div>
        </>
      )}
    </PlacesAutocomplete>
  );
}
