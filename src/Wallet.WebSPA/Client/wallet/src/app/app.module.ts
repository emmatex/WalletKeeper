import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {LoginModule} from "./login/login.module";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {AuthService} from "./auth.service";
import {CookieService} from "ngx-cookie-service";
import {HomeModule} from "./home/home.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LoginModule,
    HomeModule
  ],
  providers: [CookieService,AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
