import Axios, { AxiosRequestConfig } from "axios";
import { API_URL } from "config/Env";
import storage from "util/storage";

function authRequestInterceptor(config: AxiosRequestConfig) {
  const token = storage.getUser();
  if (token) {
    config!.headers!.authorization = `${token}`;
  }
  config!.headers!.Accept = "application/json";
  return config;
}

export const axios = Axios.create({
  baseURL: API_URL,
});

axios.interceptors.request.use(authRequestInterceptor);
axios.interceptors.response.use(
  (response) => {
    return response.data;
  },
  (error) => {
    return Promise.reject(error);
  },
);
