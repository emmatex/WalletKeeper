import {Component, OnInit} from '@angular/core';
import {Account} from '../domain/models/account.model';
import {MatDialog} from "@angular/material";
import {CreateAccountComponent} from "./create-account/create-account.component";
import {HttpClientService} from "../http-client.service";
import {getAccounts} from "../urls";

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.scss']
})
export class AccountsComponent implements OnInit {

  constructor(private dialog: MatDialog,private http:HttpClientService) {
  }

  accounts: Account[]=[];

  ngOnInit() {
    this.http.get<Account[]>(getAccounts()).subscribe(res=>{
      this.accounts = res;
    });
  }

  createAccount() {
    const dialogRef = this.dialog.open(CreateAccountComponent);
    dialogRef.afterClosed().subscribe(res=>{
      console.log(res);
    });
  }
}
