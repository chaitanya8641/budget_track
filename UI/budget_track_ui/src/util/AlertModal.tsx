import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@material-ui/core";
import * as React from "react";
import { IAlertModal } from "../models/Interfaces/IAertModal";

export default function AlertModal({ open, handleClose }: IAlertModal) {
  return (
    <div>
      <Dialog
        open={open}
        onClose={() => handleClose(false)}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          Are you sure that the translation and audio are correct?
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description" />
        </DialogContent>
        <DialogActions>
          <Button onClick={() => handleClose(true)}>Yes,I am</Button>
          <Button onClick={() => handleClose(false)} autoFocus>
            No,let me double check
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
