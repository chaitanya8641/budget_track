import { toast } from "react-toastify";

const SuccessToast = (message: string) => {
  toast.success(message, { position: toast.POSITION.BOTTOM_RIGHT });
};

const ErrorToast = (message: string) => {
  toast.error(message, { position: toast.POSITION.BOTTOM_RIGHT });
};

const WarnToast = (message: string) => {
  toast.warn(message, { position: toast.POSITION.BOTTOM_RIGHT });
};

const InfoToast = (message: string) => {
  toast.info(message, { position: toast.POSITION.BOTTOM_RIGHT });
};

export { SuccessToast, ErrorToast, WarnToast, InfoToast };
