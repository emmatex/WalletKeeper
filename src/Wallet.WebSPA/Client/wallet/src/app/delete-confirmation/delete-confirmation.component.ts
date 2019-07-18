import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material";

@Component({
  selector: 'app-delete-confirmation',
  templateUrl: './delete-confirmation.component.html',
  styleUrls: ['./delete-confirmation.component.scss']
})
export class DeleteConfirmationComponent implements OnInit {

  title: string;
  busy: boolean;
  id: number;

  constructor(public dialogRef: MatDialogRef<DeleteConfirmationComponent>,
              @Inject(MAT_DIALOG_DATA) data) {
    this.message = data.message;
    this.onDelete = data.onDelete;
  }

  onDelete: Function;
  message: string;

  ngOnInit() {

  }

  delete() {
    this.onDelete();
    this.dialogRef.close();
  }
}
