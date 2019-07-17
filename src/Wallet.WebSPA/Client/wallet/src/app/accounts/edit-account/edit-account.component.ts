import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef, MatSnackBar} from "@angular/material";
import {HttpClientService} from "../../http-client.service";
import {AccountType} from "../../domain/models/accountType.model";
import {createAccount, editAccount, getAccountTypes} from "../../urls";

@Component({
  selector: 'app-edit-account',
  templateUrl: './edit-account.component.html',
  styleUrls: ['./edit-account.component.scss']
})
export class EditAccountComponent implements OnInit {


  title: string;
  busy: boolean;
  id: number;

  constructor(public dialogRef: MatDialogRef<EditAccountComponent>,
              private http: HttpClientService,
              private snack: MatSnackBar,
              @Inject(MAT_DIALOG_DATA) data) {
    this.id = data.id;
    this.title = data.title;
  }

  ngOnInit() {

  }

  save() {
    this.busy = true;
    const account = {
      id: this.id,
      title: this.title,
    };

    this.http.put(editAccount(), account).subscribe(res => {
      this.busy = false;
      this.snack.open('Account edited successfully', 'close', {duration: 300});
      this.dialogRef.close(res);
    }, error => {
      this.busy = false;
      this.snack.open('Something went wrong!', 'close', {duration: 300});
    });
  }
}
