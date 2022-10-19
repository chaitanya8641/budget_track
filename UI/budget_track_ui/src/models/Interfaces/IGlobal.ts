export interface IGlobalCode {
  globalCode: string;
}

export interface ISideBar {
  id: number;
  screenName: string;
}

export interface IHeaderModal {
  moduleName: string;
  moduleNameModal: string;
  updatedId?: number;
}

export interface ILoading {
  isLoading: boolean;
}

export interface ILoader {
  setLoading?: (isLoading: boolean) => void | undefined;
}

export interface ILocationState {
  from: {
    pathname: string;
  };
}
