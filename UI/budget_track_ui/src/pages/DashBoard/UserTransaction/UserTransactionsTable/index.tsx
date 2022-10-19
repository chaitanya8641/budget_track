import React, { createRef, useEffect } from "react";
import { API_URLS } from "config/ApiUrls";
import { UseTable } from "hooks/useTable";
import API from "services/Api.Service";

const tableRef = createRef<any>();

const UserTransactionTable = () => {
  const [transactions, SetTransactions] = React.useState<any[]>([]);
  useEffect(() => {
    API.get(API_URLS.GetTransactions, {
      params: {},
    }).then((response: any) => {
      SetTransactions(response.data);
    });
  }, []);

  const columns = [
    { title: "Transaction NAME", field: "transactionName" },
    { title: "Transaction Amount", field: "transactionAmount" },
    { title: "Type", field: "type" },
  ];

  return (
    <div>
      <div></div>
      <div><UseTable
        refTable={tableRef}
        columns={columns}
        data={transactions}
        title="Transactions"
      /></div>
    </div>
  );
};

export default UserTransactionTable;
