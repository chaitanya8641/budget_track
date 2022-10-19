import * as React from "react";
import { IdleSessionTimeout } from "idle-session-timeout";
import {
  LoginCredentialsDTO,
  loginWithEmailAndPassword,
  UserResponse,
} from "lib/auth/helpers";
import storage from "util/storage";
import { FullPageSpinner } from "components/Spinner";
import { isTokenExpired } from "./helpers/utils";
import * as Env from "../../config/Env";

export interface AuthContextProps {
  user: UserResponse | null;
  setUser: React.Dispatch<React.SetStateAction<UserResponse | null>>;
  login: (data: LoginCredentialsDTO) => Promise<void>;
  logout: () => void;
  isLoading: boolean;
  error: any;
}

interface AuthProviderProps {
  children: React.ReactNode;
}

const AuthContext = React.createContext<AuthContextProps | undefined>({
  user: null,
  setUser: () => {},
  login: () => Promise.resolve(),
  logout: () => {},
  isLoading: false,
  error: null,
});

const handleUserResponse = (response: UserResponse) => {
  if (response) {
    storage.setUser(response);
  }
  return response;
};

function AuthProvider(props: AuthProviderProps) {
  const [user, setUser] = React.useState({});
  const [isLoading, setIsLoading] = React.useState(false);
  const [error, setError] = React.useState(null);

  const sessionTimeOut: number = parseInt(
    Env.REACT_APP_USER_SESSION_TIMEOUT_MINUTES ?? "10",
    10,
  );

  const session = new IdleSessionTimeout(sessionTimeOut * 600 * 100);

  session.onTimeOut = () => {
    logoutFn();
  };

  const loginFn = React.useCallback(
    (data: LoginCredentialsDTO) => {
      setIsLoading(true);
      try {
        return loginWithEmailAndPassword(data).then((authedUser) => {
          const userResponse = handleUserResponse(authedUser);
          setUser(userResponse.token);
          return userResponse;
        });
      } catch (err: Error | any) {
        setError(err);
      } finally {
        session.start();
        setIsLoading(false);
      }
    },
    [setIsLoading, setError, setUser],
  );

  const logoutFn = React.useCallback(() => {
    storage.clearUser();
    window.location.assign(window.location.origin as unknown as string);
  }, []);

  React.useEffect(() => {
    const loggedInUser = storage.getUser();
    if (loggedInUser) {
      const { token } = loggedInUser;
      const isExpired = isTokenExpired(token);
      if (isExpired) {
        logoutFn();
      }
    }
  }, [logoutFn]);

  const value: any = React.useMemo(() => {
    return {
      user,
      setUser,
      login: loginFn,
      logout: logoutFn,
      isLoading,
      error,
    };
  }, [user, setUser, loginFn, logoutFn, isLoading, error]);

  if (isLoading) {
    return <FullPageSpinner />;
  }

  return <AuthContext.Provider value={value} {...props} />;
}

const useAuth = () => {
  const context = React.useContext(AuthContext);
  if (context === undefined) {
    throw new Error(`useAuth must be used within a AuthProvider`);
  }
  return context;
};

export { AuthProvider, useAuth };
