import { AppRoutes } from "routes";
import { AppProvider } from "./providers/app";

function Application() {
  return (
    <AppProvider>
      <AppRoutes />
    </AppProvider>
  );
}

export default Application;
