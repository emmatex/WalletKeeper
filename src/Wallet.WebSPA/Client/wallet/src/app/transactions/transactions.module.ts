import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransactionsListComponent } from './transactions-list/transactions-list.component';
import { CreateTransactionComponent } from './create-transaction/create-transaction.component';
import {SharedModule} from "../shared/shared.module";
import {OwlDateTimeModule, OwlNativeDateTimeModule} from "ng-pick-datetime";
import {TextMaskModule} from "angular2-text-mask";



@NgModule({
  declarations: [TransactionsListComponent, CreateTransactionComponent],
  imports: [
    CommonModule,
    SharedModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    TextMaskModule
  ],
  entryComponents:[
    CreateTransactionComponent,
  ],
  exports:[
    TransactionsListComponent
  ]
})
export class TransactionsModule { }
