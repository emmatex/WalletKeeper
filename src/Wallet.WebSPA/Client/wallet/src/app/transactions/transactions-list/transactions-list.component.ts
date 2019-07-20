import {Component, OnInit, ViewChild} from '@angular/core';
import {Transaction} from "../../domain/models/transaction.model";
import {MatSnackBar, MatSort, MatTableDataSource} from "@angular/material";
import {HttpClientService} from "../../http-client.service";
import {getTransactions} from "../../urls";

@Component({
  selector: 'app-transactions-list',
  templateUrl: './transactions-list.component.html',
  styleUrls: ['./transactions-list.component.scss']
})
export class TransactionsListComponent implements OnInit {
  constructor(private http: HttpClientService, private snack: MatSnackBar) {

  }

  busy: boolean = false;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  dataSource: MatTableDataSource<Transaction>;
  transaction: Transaction[] = [];
  displayedColumns: string[] = ['transactionTypeTitle', 'accountTitle', 'amount', 'transactionCategoryTitle', 'date'];

  ngOnInit() {
    this.busy = true;
    this.http.get<Transaction[]>(getTransactions()).subscribe(res => {
      this.transaction = res;
      this.dataSource = new MatTableDataSource(this.transaction);
      this.sort.sort({id: "date", start: "desc", disableClear: false});
      this.dataSource.sort = this.sort;
      this.busy = false;
    }, err => {
      this.snack.open('Something went wrong!', 'close', {duration: 300});
      this.busy = false;
    });
  }

}
