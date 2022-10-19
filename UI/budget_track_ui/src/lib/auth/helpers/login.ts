import { API_URLS } from "config/ApiUrls";
import { axios } from "lib/axios";

import { UserResponse } from "./types";

export type LoginCredentialsDTO = {
  userName: string;
  password: string;
};

export const loginWithEmailAndPassword = (
  data: LoginCredentialsDTO,
): Promise<UserResponse> => {
  return axios.post(API_URLS.Login, data);
};
