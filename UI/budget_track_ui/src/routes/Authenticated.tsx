import { Route, Routes } from "react-router-dom";
import routePaths from "config/RoutePaths";
import Dashboard from "pages/DashBoard/Dashboard";
import Unauthorised from "pages/DashBoard/Unauthorised";
import NotFound from "pages/NotFound";
import AddDebitTransaction from "pages/DashBoard/UserTransaction/AddDebitTransaction";
import AddCreditTransaction from "pages/DashBoard/UserTransaction/AddCreditTransaction";

export const AuthenticatedApp = () => {
  return (
    <Routes>
      <Route path={routePaths.DASHBOARD} element={<Dashboard />} />
      <Route path={`${routePaths.UNAUTHORISED}`} element={<Unauthorised />} />
      <Route path={`${routePaths.NOTFOUND}`} element={<NotFound />} />
      <Route path={`${routePaths.ADDDEBITTRANSACTION}`} element={<AddDebitTransaction />} />
      <Route path={`${routePaths.ADDCREDITTRANSACTION}`} element={<AddCreditTransaction />} />
    </Routes>
  );
};
