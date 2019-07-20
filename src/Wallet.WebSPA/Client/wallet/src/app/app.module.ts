import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {LoginModule} from "./login/login.module";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {AuthService} from "./auth.service";
import {CookieService} from "ngx-cookie-service";
import {HomeModule} from "./home/home.module";
import { ToolbarComponent } from './toolbar/toolbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import {AccountsModule} from "./accounts/accounts.module";
import {HttpClientService} from "./http-client.service";
import { DeleteConfirmationComponent } from './delete-confirmation/delete-confirmation.component';
import {CommonModule} from "@angular/common";
import {SharedModule} from "./shared/shared.module";
import {TransactionsModule} from "./transactions/transactions.module";
import 'hammerjs';


@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    SidebarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CommonModule,
    LoginModule,
    HomeModule,
    AccountsModule,
    SharedModule,
    TransactionsModule,
  ],
  providers: [CookieService,HttpClientService,AuthService],
  bootstrap: [AppComponent],
  entryComponents:[DeleteConfirmationComponent]
})
export class AppModule { }
