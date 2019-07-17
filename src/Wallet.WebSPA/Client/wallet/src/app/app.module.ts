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
import {MatButtonModule, MatIconModule, MatInputModule, MatMenuModule, MatToolbarModule} from "@angular/material";
import { SidebarComponent } from './sidebar/sidebar.component';
import {AccountsModule} from "./accounts/accounts.module";
import {HttpClientService} from "./http-client.service";
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    SidebarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatToolbarModule,
    MatButtonModule,
    FormsModule,
    MatInputModule,
    MatMenuModule,
    LoginModule,
    HomeModule,
    AccountsModule
  ],
  providers: [CookieService,HttpClientService,AuthService,],
  bootstrap: [AppComponent]
})
export class AppModule { }
