import {Component, Inject, OnInit} from '@angular/core';
import {TransactionCategory} from "../../domain/models/transactionCategory.model";
import {HttpClientService} from "../../http-client.service";
import {createTransaction, getAccounts, getCategories} from "../../urls";
import {MAT_DIALOG_DATA, MatChipInputEvent, MatDialogRef} from "@angular/material";
import {Account} from "../../domain/models/account.model";
import {COMMA, ENTER} from "@angular/cdk/keycodes";
import createNumberMask from 'text-mask-addons/dist/createNumberMask'
import {Transaction} from "../../domain/models/transaction.model";
import {ToastService} from "../../toast.service";

@Component({
  selector: 'app-create-transaction',
  templateUrl: './create-transaction.component.html',
  styleUrls: ['./create-transaction.component.scss']
})
export class CreateTransactionComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<CreateTransactionComponent>,
              private http: HttpClientService,
              private toast: ToastService,
              @Inject(MAT_DIALOG_DATA) data) {
    this.type = data.type;
    this.typeId = data.typeId;

  }

  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  busy: boolean;
  accounts: Account[];
  selectedAccount: Account;
  transactionCategories: TransactionCategory[];
  selectedTransactionsCategory: TransactionCategory;
  amount: string;
  date: Date;
  typeId: number;
  type: string;
  notes: string = "";
  tags: string[] = [];
  tag: string;
  mask: string = this.accountChanged();
  sufix: string;

  ngOnInit() {
    const accountsObs = this.http.get<Account[]>(getAccounts());
    accountsObs.subscribe(res => {
      this.accounts = res;
      if (this.accounts.length > 0)
        this.selectedAccount = this.accounts[0];
    });
    const categoriesObs = this.http.get<TransactionCategory[]>(getCategories(this.typeId));
    categoriesObs.subscribe(res => {
      this.transactionCategories = res;
      if (this.transactionCategories.length > 0)
        this.selectedTransactionsCategory = this.transactionCategories[0];
    });

    this.date = new Date();
  }

  save() {
    this.busy = true;
    const transaction = {
      transactionCategoryId: this.selectedTransactionsCategory.id,
      transactionTypeId: this.typeId,
      tags: this.tags,
      notes: this.notes,
      date: this.date,
      amount: Number(this.amount.replace(this.sufix, '')),
      currencyId: this.selectedAccount.currencyId,
      currencyCode: this.selectedAccount.currencyCode,
      currencyTitle: this.selectedAccount.currencyTitle,
      accountId: this.selectedAccount.id
    };
    this.http.post(createTransaction(), transaction).subscribe(res => {
      this.dialogRef.close(res);
      this.toast.operationSuccess();
      this.busy = false
    }, err => {
      this.toast.genericError();
      this.busy = false
    })
  }

  addTag(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.tags.push(value.trim());
    }

    if (input) {
      input.value = '';
    }
  }

  removeTag(tag: string) {
    this.tags.slice(this.tags.indexOf(tag), 1);
  }

  accountChanged() {
    this.sufix = this.selectedAccount ? '  ' + this.selectedAccount.currencyCode : '  USD';
    const mask = createNumberMask({
      suffix: this.sufix,
      allowDecimal: true,
      includeThousandsSeparator: true,
      prefix: ''
    });
    this.mask = mask;
    return mask;
  }
}
