import {Component, OnInit} from '@angular/core';
import {Account} from '../domain/models/account.model';
import {MatDialog} from "@angular/material";
import {CreateAccountComponent} from "./create-account/create-account.component";
import {HttpClientService} from "../http-client.service";
import {deleteAccount, getAccount, getAccounts} from "../urls";
import {forkJoin} from "rxjs";
import {EditAccountComponent} from "./edit-account/edit-account.component";
import {DeleteConfirmationComponent} from "../delete-confirmation/delete-confirmation.component";
import {ToastService} from "../toast.service";

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.scss']
})
export class AccountsComponent implements OnInit {

  constructor(private dialog: MatDialog, private http: HttpClientService, private toast:ToastService) {
  }

  accounts: Account[] = [];
  busy: boolean = false;

  ngOnInit() {
    this.busy = true;
    const accountsOb = this.http.get<Account[]>(getAccounts());
    accountsOb.subscribe(res => {
      this.accounts = res;
    });
    forkJoin(accountsOb).subscribe(() => this.busy = false,() => {
      this.busy = false;
      this.toast.genericError();
    });
  }

  createAccount() {
    const dialogRef = this.dialog.open(CreateAccountComponent);
    dialogRef.afterClosed().subscribe(res => {
      if (!res)
        return;

      this.http.get<Account>(getAccount(res.id)).subscribe(res => this.accounts.push(res));
    });
  }

  edit(account: Account) {
    const dialogRef = this.dialog.open(EditAccountComponent, {data: account});
    dialogRef.afterClosed().subscribe(() => {
      this.http.get<Account>(getAccount(account.id)).subscribe(res => {
        const old = this.accounts.indexOf(account);
        this.accounts[old] = res;
      });
    });
  }

  delete(account: Account) {
    this.dialog.open(DeleteConfirmationComponent, {
      data: {
        message: "Deleting this account will remove all related transactions, are you sure you want to delete it?",
        onDelete: () => {
          this.busy = true;
          this.http.delete(deleteAccount(account.id)).subscribe(() => {
            const old = this.accounts.indexOf(account);
            this.accounts.splice(old, 1);
            this.toast.show("Account deleted successfully.");
            this.busy = false;
          }, () => {
           this.toast.genericError();
            this.busy = false;
          });
        }
      }
    });
  }
}
