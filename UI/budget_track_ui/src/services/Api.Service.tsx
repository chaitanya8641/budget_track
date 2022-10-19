import Axios from "axios";
import storage from "util/storage";
import { ErrorToast } from "../components/Toaster";
import { API_URLS } from "../config/ApiUrls";
import * as Env from "../config/Env";

const API = Axios.create({
  baseURL: Env.API_URL,
});
API.interceptors.request.use(
  (conf: any) => {

    if (storage.getUser()) {
      const tokenDetail = storage.getUser();
      conf.headers = {
        Authorization: `Bearer ${tokenDetail?.token}`,
      };
    }
    return conf;
  },
  (error) => {
    return Promise.reject(error);
  },
);
API.interceptors.response.use(
  (next) => {
    return Promise.resolve(next);
  },
  async (error) => {

    const statusCode = error?.response?.status;
    if (statusCode === 401) {
      const originalRequest = error.config;
      const TokenDetail = storage.getUser();
      const newTokenResponse = await API.post(API_URLS.RefreshToken, {
        token: TokenDetail?.data?.token,
      });
      TokenDetail.data.token = newTokenResponse?.data?.data?.token;
      storage.setUser(TokenDetail);
      originalRequest.headers.Authorization = `Bearer ${newTokenResponse.data?.data?.token}`;
      const responseUpdated = await Axios(originalRequest);
      return Promise.resolve(responseUpdated);
    }
    ErrorToast(error.response.data || error.response.data.message);
    return Promise.reject(error.response.data || error.response.data.message);
  },
);
export default API;
