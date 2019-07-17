import {Component, OnInit} from '@angular/core';
import {Account} from '../domain/models/account.model';
import {MatDialog} from "@angular/material";
import {CreateAccountComponent} from "./create-account/create-account.component";
import {HttpClientService} from "../http-client.service";
import {getAccount, getAccounts} from "../urls";
import {forkJoin, Observable} from "rxjs";
import {EditAccountComponent} from "./edit-account/edit-account.component";

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.scss']
})
export class AccountsComponent implements OnInit {

  constructor(private dialog: MatDialog,private http:HttpClientService) {
  }

  accounts: Account[]=[];
busy :boolean = false;
  ngOnInit() {
    this.busy = true;
    const accountsOb =this.http.get<Account[]>(getAccounts());
    accountsOb.subscribe(res=>{
      this.accounts = res;
    });
    forkJoin(accountsOb).subscribe(()=> this.busy = false);
  }

  createAccount() {
    const dialogRef = this.dialog.open(CreateAccountComponent);
    dialogRef.afterClosed().subscribe(res=>{
      if(!res)
        return;
      
      this.http.get<Account>(getAccount(res.id)).subscribe(res=> this.accounts.push(res));
    });
  }

  edit(account: Account) {
    const dialogRef = this.dialog.open(EditAccountComponent,{data:account});
    dialogRef.afterClosed().subscribe(()=>{
      this.http.get<Account>(getAccount(account.id)).subscribe(res=> {
        const old = this.accounts.indexOf(account);
        this.accounts[old] = res;
      });
    });
  }
}
