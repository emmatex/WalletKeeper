import {Component, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
import {Transaction} from "../../domain/models/transaction.model";
import {MatDialog, MatSnackBar, MatSort, MatTableDataSource} from "@angular/material";
import {HttpClientService} from "../../http-client.service";
import {getTransaction, getTransactions} from "../../urls";
import {CreateTransactionComponent} from "../create-transaction/create-transaction.component";
import {TransactionTypes} from "../../domain/models/transactionTypes";

@Component({
  selector: 'app-transactions-list',
  templateUrl: './transactions-list.component.html',
  styleUrls: ['./transactions-list.component.scss']
})
export class TransactionsListComponent implements OnInit {
  constructor(private http: HttpClientService, private snack: MatSnackBar, private dialog: MatDialog) {

  }

  @Output()
    transactionCreates:EventEmitter<Transaction> = new EventEmitter();

  busy: boolean = false;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  dataSource: MatTableDataSource<Transaction>;
  transaction: Transaction[] = [];
  displayedColumns: string[] = ['transactionTypeTitle', 'accountTitle', 'amount', 'transactionCategoryTitle', 'date'];

  ngOnInit() {
    this.busy = true;
    this.http.get<Transaction[]>(getTransactions()).subscribe(res => {
      this.transaction = res;
      this.updateDataSource();
      this.dataSource.sort = this.sort;
      this.busy = false;
    }, err => {
      this.snack.open('Something went wrong!', 'close', {duration: 300});
      this.busy = false;
    });
  }

  createExpense() {
    const dialogRef = this.dialog.open(CreateTransactionComponent, {
      data: {
        typeId: TransactionTypes.Expense,
        type: "expense",
      },
      panelClass: ['create-transaction', 'create-transaction-expense']
    });
    dialogRef.afterClosed().subscribe(res => {
      this.http.get<Transaction>(getTransaction(res.id)).subscribe(trans => {
        this.transaction.push(trans);
        this.transactionCreates.emit(trans);
        this.updateDataSource();
      })
    });
  }

  createIncome() {
    this.dialog.open(CreateTransactionComponent, {
      data: {
        typeId: TransactionTypes.Income,
        type: "income",
      },
      panelClass: ['create-transaction', 'create-transaction-income']
    });
  }

  private updateDataSource() {
    this.dataSource = new MatTableDataSource(this.transaction);
    this.sort.sort({id: "date", start: "desc", disableClear: false});
  }
}
