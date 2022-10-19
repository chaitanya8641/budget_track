import MaterialTable from "material-table";

export const UseTable = (props: any) => {
  return (
    <div className="table">
      {props.columns && (
        <MaterialTable
          tableRef={props.refTable}
          title={props.title}
          columns={props.columns}
          data={props.data}
          options={{
            filtering: props.filtering ? props.filtering : false,
            paging: true,
            pageSize: 10,
            emptyRowsWhenPaging: true,
            headerStyle: {
              borderColor: "rgb(184 184 184)",
              borderWidth: "1px",
              fontFamily: "verdana",
            },
            actionsColumnIndex: -1,
            pageSizeOptions: [5, 10, 25, 50, 100],
            maxBodyHeight: 400,
          }}
        />
      )}
    </div>
  );
};

export default UseTable;
