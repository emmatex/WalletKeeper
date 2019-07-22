import {Component, OnInit} from '@angular/core';
import {HttpClientService} from "../http-client.service";
import {HttpParams} from "@angular/common/http";
import {sumTransactionsByType} from "../urls";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  expenses: string;
  income: string;

  constructor(private http: HttpClientService) {
  }

  ngOnInit() {
    this.updateTotals();
  }

  updateTotals() {
    this.http.get(sumTransactionsByType(), new HttpParams().set('transactionType', '0').set('days', '30'))
      .subscribe(res => this.income = res.toString());
    this.http.get(sumTransactionsByType(), new HttpParams().set('transactionType', '1').set('days', '30'))
      .subscribe(res => this.expenses = res.toString());
  }

  transactionCreated() {
    this.updateTotals();
  }
}
