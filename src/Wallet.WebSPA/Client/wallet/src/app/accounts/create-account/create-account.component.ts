import {Component, OnInit} from '@angular/core';
import {MatDialogRef, MatSnackBar} from "@angular/material";
import {AccountType} from "../../domain/models/accountType.model";
import {createAccount, getAccountTypes} from "../../urls";
import {HttpClientService} from "../../http-client.service";

@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.scss']
})
export class CreateAccountComponent implements OnInit {

  types: AccountType[];
  selectedType: number;
  title: string;

  busy: boolean;

  constructor(public dialogRef: MatDialogRef<CreateAccountComponent>, private http: HttpClientService, private snack: MatSnackBar) {
  }

  ngOnInit() {
    this.types = [];
    this.http.get<AccountType[]>(getAccountTypes()).subscribe(res => {
      this.types = res;

      if (this.types && this.types.length > 0)
        this.selectedType = this.types[0].id;
    });
  }

  save() {
    this.busy = true;
    const account = {
      title: this.title,
      accountTypeId: this.selectedType
    };

    this.http.post(createAccount(), account).subscribe(res => {
      this.busy = false;
      this.snack.open('Account created successfully','close',{duration:300});
      this.dialogRef.close(res);
    }, error => {
      this.busy = false;
      this.snack.open('Something went wrong!','close',{duration:300});
    });
  }
}
