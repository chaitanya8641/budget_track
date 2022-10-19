import { UserResponse } from "lib/auth/helpers/types";

const localStorageKey = "and_wider_react_";

const storage = {
  getUser: () => {
    return JSON.parse(
      window.localStorage.getItem(`${localStorageKey}user`) as string,
    );
  },
  setUser: (data: UserResponse) => {
    window.localStorage.setItem(`${localStorageKey}user`, JSON.stringify(data));
  },
  clearUser: () => {
    window.localStorage.removeItem(`${localStorageKey}user`);
  },
};

export default storage;
