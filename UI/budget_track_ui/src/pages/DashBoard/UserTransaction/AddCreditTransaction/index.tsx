import { useNavigate } from "react-router-dom";
import { Grid } from "@material-ui/core";
import "./Style.css";
import { Form, useForm } from "../../../../hooks/useForm";
import Controls from "../../../../components/Controls";
import { ICreateTransaction } from "../../../../models/Interfaces/ITransaction";
import API from "../../../../services/Api.Service";
import { API_URLS } from "../../../../config/ApiUrls";
import { SuccessToast } from "../../../../components/Toaster";
import routePaths from "../../../../config/RoutePaths";

const fieldError = {} as ICreateTransaction;

export default function AddCreditTransaction() {
    const navigate = useNavigate();
    const initialFValues: ICreateTransaction = {
        transactionName: "",
        transactionAmount: "",
    };
    const validate = (fieldValues = values) => {
        if ("transactionName" in fieldValues)
            fieldError.transactionName = fieldValues.transactionName
                ? ""
                : "Transaction Name is required.";
        if ("transactionAmount" in fieldValues)
            fieldError.transactionAmount = fieldValues.transactionAmount
                ? ""
                : "Transaction Amount is required.";
        setErrors({
            ...fieldError,
        });

        if (fieldValues === values)
            return Object.values(fieldError).every((x) => x === "");
    };
    const { values, setErrors, handleInputChange } = useForm(
        initialFValues,
        true,
        validate,
    );
    const handleSubmit = (e: any) => {
        e.preventDefault();
        if (validate()) {
            API.post(API_URLS.AddCreditTransaction, {
                TransactionName: values.transactionName,
                TransactionAmount: values.transactionAmount
            })
                .then((res: any) => {
                    SuccessToast(res?.message);
                    navigate(routePaths.DASHBOARD);
                })
                .finally(() => {
                });
        }
    };
    return (
        <Form onSubmit={handleSubmit}>
            <div className="container-view">
                <Grid container>
                    <Grid item xs={12} sm={2} md={2} />
                    <Grid item xs={12} sm={8} md={8}>
                        <Grid container>
                            <Grid item xs={12} sm={12} md={2}></Grid>
                            <Grid item xs={12} sm={12} md={8}>
                                <Grid container>
                                    <Grid item xs={12} className="grid-custom-spacing">
                                        <h3>ADD CREDIT TRANSACTION</h3>
                                    </Grid>
                                    <Grid item xs={12} sm={12} md={12} className="grid-custom-spacing">
                                        <Controls.Input
                                            id="transactionName"
                                            name="transactionName"
                                            label="Transaction Name*"
                                            value={values.transactionName}
                                            onChange={handleInputChange}
                                            error={fieldError.transactionName}
                                        />
                                    </Grid>
                                    <Grid item xs={12} sm={12} md={12} className="grid-custom-spacing">
                                        <Controls.Input
                                            id="transactionAmount"
                                            name="transactionAmount"
                                            label="Transaction Amount*"
                                            value={values.transactionAmount}
                                            onChange={handleInputChange}
                                            error={fieldError.transactionAmount}
                                        />
                                    </Grid>
                                    <br/>
                                    <Grid item xs={12} sm={12} md={12} className="grid-custom-spacing">
                                        <div className="custom-floatRight">
                                            <Controls.Button
                                                text="CLOSE"
                                                color="default"
                                                onClick={() => {
                                                    navigate(routePaths.DASHBOARD);
                                                }}
                                            />
                                            <Controls.Button type="submit" text="SAVE" />
                                        </div>
                                    </Grid>
                                </Grid>
                            </Grid>
                            <Grid item xs={12} sm={12} md={2}></Grid>
                        </Grid>
                    </Grid>
                    <Grid item xs={12} sm={2} md={2} />
                </Grid>
            </div>
        </Form>
    );
}