import { ILoading } from "../../models/Interfaces/IGlobal";
import "./Style.css";

export default function Loading({ isLoading }: ILoading) {
  return isLoading ? (
    <div className="overlay">
      <div className="cv-spinner">
        <div className="spinner" />
      </div>
    </div>
  ) : (
    <span />
  );
}
