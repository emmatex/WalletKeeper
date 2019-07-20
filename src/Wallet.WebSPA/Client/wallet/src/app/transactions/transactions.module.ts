import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransactionsListComponent } from './transactions-list/transactions-list.component';
import { CreateTransactionComponent } from './create-transaction/create-transaction.component';
import {SharedModule} from "../shared/shared.module";



@NgModule({
  declarations: [TransactionsListComponent, CreateTransactionComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports:[
    TransactionsListComponent
  ]
})
export class TransactionsModule { }
