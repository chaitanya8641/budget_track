import "./Style.css";

export const Spinner = () => {
  return (
    <div className="overlay">
      <div className="cv-spinner">
        <div className="spinner" />
      </div>
    </div>
  );
};

export const FullPageSpinner = () => {
  return (
    <div
      style={{
        width: "100vw",
        height: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Spinner />
    </div>
  );
};
