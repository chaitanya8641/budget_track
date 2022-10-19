import { Navigate, Route, Routes } from "react-router-dom";
import routePaths from "config/RoutePaths";
import SignIn from "pages/Auth/SignIn";
import Unauthorised from "pages/DashBoard/Unauthorised";

export const UnauthenticatedApp = () => {
  return (
    <Routes>
      <Route path={routePaths.SIGNIN} element={<SignIn />} />
      <Route path={routePaths.UNAUTHORISED} element={<Unauthorised />} />
      <Route path="*" element={<Navigate to={routePaths.SIGNIN} />} />
    </Routes>
  );
};
