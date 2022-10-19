import React, { useState, useEffect } from "react";
import { Grid } from "@material-ui/core";
import Controls from "components/Controls";
import routePaths from "config/RoutePaths";
import { useNavigate } from "react-router-dom";
import { API_URLS } from "config/ApiUrls";
import API from "services/Api.Service";
import { useAuth as useNewAuth } from "../../../lib/auth";
import UserTransaction from "../UserTransaction";

const Dashboard = () => {
  const auth = useNewAuth();
  const navigate = useNavigate();
  const [debitBalance, SetDebitBalance] = useState<any[]>([]);
  const [creditBalance, SetCreditBalance] = useState<any[]>([]);
  useEffect(() => {
    API.get(API_URLS.GetDebitAccountBalance, {
      params: {},
    }).then((response: any) => {
      SetDebitBalance(response.data.accountBalance);
    });
  }, []);
  useEffect(() => {
    API.get(API_URLS.GetCreditAccountBalance, {
      params: {},
    }).then((response: any) => {
      SetCreditBalance(response.data.accountBalance);
    });
  }, []);

  return (
    <div className="container-view">
      <Grid container>
        <Grid item xs={1} sm={1} />
        <Grid item xs={10} sm={10}>
          <Grid container spacing={3}>
            <Grid item xs={12} sm={12}>
              <div className="custom-floatRight">
                <Controls.Button
                  variant="contained"
                  onClick={() => navigate(routePaths.ADDDEBITTRANSACTION)}
                  text="Add Debit Transaction"
                />
                <Controls.Button
                  variant="contained"
                  onClick={() => navigate(routePaths.ADDCREDITTRANSACTION)}
                  text="Add Credit Transaction"
                />
                <Controls.Button
                  onClick={() => {
                    auth.logout();
                  }}
                  text="Logout"
                />
              </div>
            </Grid>
            <Grid item xs={12} sm={12}>
              <div className="custom-floatRight">
                <p>Check Debit Balance : <span className="color-blue">{debitBalance}</span></p>
                <p>Check Credit Balance : <span className="color-blue" >{creditBalance}</span></p>
              </div>
            </Grid>
          </Grid>
          <Grid container>
            <Grid item xs={12} sm={12}>
              <div>
                <UserTransaction />
              </div>
            </Grid>
          </Grid>
        </Grid>
        <Grid item xs={1} sm={1} />
      </Grid>
    </div>
  );
};

export default Dashboard;

