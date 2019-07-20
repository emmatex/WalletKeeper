import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import {TransactionsModule} from "../transactions/transactions.module";
import {SharedModule} from "../shared/shared.module";
import {MatTableModule} from "@angular/material";



@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    SharedModule,
    TransactionsModule,

  ]
})
export class HomeModule { }
