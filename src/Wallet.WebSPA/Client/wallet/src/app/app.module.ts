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
import {MatButtonModule, MatIconModule, MatToolbarModule} from "@angular/material";
import { SidebarComponent } from './sidebar/sidebar.component';

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
    LoginModule,
    HomeModule,
    MatButtonModule
  ],
  providers: [CookieService,AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
