import { ILoader } from "./IGlobal";

export interface IAuth {
  auth?: {
    token: string;
  };
  setAuth?: ({}) => void;
}

export interface ISignIn {
  userName?: string;
  password?: string | number;
}

export interface ISignInProps extends ILoader {}
export interface IRegisterAdministratorProps extends ILoader {}
