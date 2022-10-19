import React from "react";
import { FullPageSpinner } from "components/Spinner";
import { useAuth } from "lib/auth";
import { isEmpty } from "util/CommonFunctions";
import storage from "util/storage";
import { AuthenticatedApp } from "./Authenticated";
import { UnauthenticatedApp } from "./Unauthenticated";

export const AppRoutes = () => {
  const auth = useAuth();
  const user = isEmpty(auth.user) ? null : auth.user;
  const userToken = storage.getUser();

  return (
    <React.Suspense fallback={<FullPageSpinner />}>
      {userToken || user ? <AuthenticatedApp /> : <UnauthenticatedApp />}
    </React.Suspense>
  );
};
