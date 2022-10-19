import "react-toastify/dist/ReactToastify.css";
import "../App.css";
import * as React from "react";
import { ErrorBoundary, FallbackProps } from "react-error-boundary";
import { HelmetProvider } from "react-helmet-async";
import { QueryClientProvider } from "react-query";
import { ReactQueryDevtools } from "react-query/devtools";
import { queryClient } from "lib/react-query";
import { AuthProvider } from "lib/auth";
import { ToastContainer } from "react-toastify";
import { BrowserRouter as Router } from "react-router-dom";
import { FullPageSpinner } from "components/Spinner";

const ErrorFallback = ({ error, resetErrorBoundary }: FallbackProps) => {
  return (
    <div role="alert">
      <h2>Ooops, something went wrong 😞</h2>
      <span>{error.message}</span>
      <button type="button" onClick={resetErrorBoundary}>
        Refresh
      </button>
    </div>
  );
};

type AppProviderProps = {
  children: React.ReactNode;
};

export const AppProvider = ({ children }: AppProviderProps) => {
  return (
    <React.Suspense fallback={<FullPageSpinner />}>
      <ErrorBoundary
        FallbackComponent={ErrorFallback}
        onReset={() => {
          window.location.assign(window.location.origin);
        }}
      >
        <HelmetProvider>
          <QueryClientProvider client={queryClient}>
            {process.env.NODE_ENV !== "test" && <ReactQueryDevtools />}
            <ToastContainer />
            <Router>
              <AuthProvider>{children}</AuthProvider>
            </Router>
          </QueryClientProvider>
        </HelmetProvider>
      </ErrorBoundary>
    </React.Suspense>
  );
};
