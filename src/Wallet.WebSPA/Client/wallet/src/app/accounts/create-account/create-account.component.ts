import {Component, OnInit} from '@angular/core';
import {MatDialogRef, MatSnackBar} from "@angular/material";
import {AccountType} from "../../domain/models/accountType.model";
import {createAccount, getAccountTypes, getCurrencies} from "../../urls";
import {HttpClientService} from "../../http-client.service";
import {Currency} from "../../domain/models/currency.model";

@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.scss']
})
export class CreateAccountComponent implements OnInit {

  types: AccountType[];
  selectedType: number;

  currencies:Currency[];
  selectedCurrency:Currency;

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
    this.http.get<Currency[]>(getCurrencies()).subscribe(res => {
      this.currencies = res;
      if (this.currencies && this.currencies.length > 0)
        this.selectedCurrency = this.currencies[0];
    });
  }

  save() {
    this.busy = true;
    const account = {
      title: this.title,
      accountTypeId: this.selectedType,
      currencyId:this.selectedCurrency.id,
      currencyCode:this.selectedCurrency.code,
      currencyTitle:this.selectedCurrency.title,
      currencySymbol:this.selectedCurrency.symbol,
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
