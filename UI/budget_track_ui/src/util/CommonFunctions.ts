export const getDropDownOptions = (
  data: any,
  keyName: string,
  labelKeyName: string,
) => {
  const dropDownOptionList = data.map((x: any) => {
    return { key: x[keyName], label: x[labelKeyName] };
  });
  return dropDownOptionList;
};

export const isEmpty = (obj: any) => Object.keys(obj).length === 0;
