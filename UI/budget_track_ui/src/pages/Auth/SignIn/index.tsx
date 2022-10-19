import { SyntheticEvent } from "react";
import { Grid } from "@material-ui/core";
import { useNavigate } from "react-router-dom";
import { useAuth as useNewAuth } from "lib/auth";
import Controls from "components/Controls";
import { Form, useForm } from "hooks/useForm";
import { 
  ISignIn 
} from "models/Interfaces/IAuth";
import "./Style.css";
import routePaths from "config/RoutePaths";
import { SuccessToast } from "components/Toaster";
import { UserResponse } from "lib/auth/helpers";

const initialFValues: ISignIn = {
  userName: "",
  password: "",
};

const obj = {} as ISignIn;

export default function SignIn() {
  const { login }: any = useNewAuth();
  const navigate: any = useNavigate();
  const validate = (fieldValues = values) => {
    if ("userName" in fieldValues)
      obj.userName = fieldValues.userName ? "" : "userName is required.";
    if ("password" in fieldValues)
      obj.password = fieldValues.password ? "" : "Password is required.";
    setErrors({
      ...obj,
    });

    if (fieldValues === values)
      return Object.values(obj).every((x) => x === "");
  };
  const { values, setErrors, handleInputChange } = useForm(
    initialFValues,
    true,
    validate,
  );
  const handleSubmitNew = async (e: SyntheticEvent) => {
    e.preventDefault();
    if (validate()) {
      const { userName, password } = values;
      try {
        await login({ userName, password }).then((loginResponse:UserResponse) => {         
          SuccessToast(loginResponse.token);
          navigate(routePaths.DASHBOARD, { replace: true });
        });
      }
      catch (error) { 
        
      }
    }
  };
  return (
    <Form onSubmit={handleSubmitNew}>
      <div className="container-view">
        <Grid container>
          <Grid item xs={12} sm={3} md={4} />
          <Grid item xs={12} sm={6} md={4}>
            <div>
              <h1>LOGIN</h1>
            </div>
            <Controls.Input
              id="userName"
              name="userName"
              label="User name address*"
              value={values.userName}
              onChange={handleInputChange}
              error={obj.userName}
              cName="text-input"
              variant="outlined"
            />
            <Controls.PasswordInput
              id="password"
              label="Your password*"
              name="password"
              value={values.password}
              onChange={handleInputChange}
              error={obj.password}
              cName="text-input"
              variant="outlined"
            />
            <br />
            <br />
            <div>
              <Controls.Button type="submit" text="Log in" />
            </div>
            <br />
          </Grid>
          <Grid item xs={12} sm={3} md={4} />
        </Grid>
      </div>
    </Form>
  );
}
