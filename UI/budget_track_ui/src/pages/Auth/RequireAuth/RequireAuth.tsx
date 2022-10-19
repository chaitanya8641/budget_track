import React from "react";
import { Navigate, Outlet } from "react-router-dom";
import routePaths from "config/RoutePaths";
import storage from "util/storage";
import { useAuth as useNewAuth } from "lib/auth";

const RequireAuth = () => {
  const auth = useNewAuth();
  const currentUser = storage.getUser();
  React.useEffect(() => {
    if (currentUser) {
      auth.setUser(currentUser);
    }
  }, []);

  const authRender = () => {
    if (auth.user?.token) {
      return <Navigate to={routePaths.UNAUTHORISED} />;
    }
    return <Navigate to={routePaths.SIGNIN} />;
  };
  return authRender();
};

export default RequireAuth;
