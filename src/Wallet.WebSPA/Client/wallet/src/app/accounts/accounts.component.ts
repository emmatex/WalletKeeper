import {Component, OnInit} from '@angular/core';
import {Account} from '../domain/models/account.model';
import {MatDialog} from "@angular/material";
import {CreateAccountComponent} from "./create-account/create-account.component";
import {HttpClientService} from "../http-client.service";
import {getAccounts} from "../urls";
import {forkJoin, Observable} from "rxjs";

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
      console.log(res);
    });
  }
}
