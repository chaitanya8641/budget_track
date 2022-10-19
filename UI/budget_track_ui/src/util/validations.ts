export const phoneNumber = (
  values: any,
  obj: any,
  setErrors: any,
  errors: any,
) => {
  const fieldValues = values;
  const temp = { ...errors };
  const re =
    /(\+\d{1,3}\s?)?((\(\d{3}\)\s?)|(\d{3})(\s|-?))(\d{3}(\s|-?))(\d{4})(\s?(([E|e]xt[:|.|]?)|x|X)(\s?\d+))?/g;

  if ("phoneNumber" in fieldValues)
    if (!re.test(fieldValues.phoneNumber)) {
      obj.phoneNumber = "Please enter a valid phone number.";
    }
  setErrors({
    ...obj,
  });
  if (fieldValues === values) return Object.values(temp).every((x) => x === "");
};

export const validateEmail = (
  values: any,
  obj: any,
  setErrors: any,
  errors: any,
) => {
  const fieldValues = values;
  const temp = { ...errors };
  const re = /\S+@\S+\.\S+/;

  if ("email" in fieldValues)
    if (!re.test(fieldValues.email)) {
      obj.email = "Please enter a valid email.";
    }
  setErrors({
    ...obj,
  });
  if (fieldValues === values) return Object.values(temp).every((x) => x === "");
};

export const validatePassword = (
  values: any,
  obj: any,
  setErrors: any,
  errors: any,
) => {
  const fieldValues = values;
  const temp = { ...errors };
  const re = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_])[A-Za-z\d\W_]{8,}$/;

  if ("password" in fieldValues)
    if (!re.test(fieldValues.password)) {
      obj.password =
        "Password require : 8 characters, 5 different characters, 1 lower case, 1 upper case, one digit and one special character.";
    }
  setErrors({
    ...obj,
  });
  if (fieldValues === values) return Object.values(temp).every((x) => x === "");
};

export const validatePasswords = (
  values: any,
  obj: any,
  setErrors: any,
  errors: any,
) => {
  const fieldValues = values;
  const temp = { ...errors };

  if ("password" in fieldValues)
    if ("password" in fieldValues && "passwordConfirm" in fieldValues)
      if (fieldValues.password !== fieldValues.passwordConfirm) {
        obj.passwordConfirm = "Passwords do not match.";
      }
  setErrors({
    ...obj,
  });
  if (fieldValues === values) return Object.values(temp).every((x) => x === "");
};
