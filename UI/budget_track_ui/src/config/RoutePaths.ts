const routePaths = {
  // Auth paths
  NOTFOUND: `*`, //✅
  SIGNIN: `/signin`, //✅
  SIGNOUT: `/signout`, //✅
  // Authorised paths
  DASHBOARD: `/`, //✅
  UNAUTHORISED: `/unauthorised`,
  ADDDEBITTRANSACTION:'/adddebittransaction',
  ADDCREDITTRANSACTION:'/addcredittransaction',
};

export default routePaths;
