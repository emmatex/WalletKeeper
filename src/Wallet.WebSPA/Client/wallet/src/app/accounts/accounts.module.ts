import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountsComponent } from './accounts.component';
import {
  MatButtonModule,
  MatDialogModule,
  MatExpansionModule,
  MatInputModule,
  MatListModule, MatProgressBarModule,
  MatSelectModule, MatSnackBarModule
} from "@angular/material";
import { CreateAccountComponent } from './create-account/create-account.component';
import {FormsModule} from "@angular/forms";
import { EditAccountComponent } from './edit-account/edit-account.component';
import {SharedModule} from "../shared/shared.module";



@NgModule({
  declarations: [AccountsComponent, CreateAccountComponent, EditAccountComponent],
  imports: [
    CommonModule,
    SharedModule,
  ],
  entryComponents:[CreateAccountComponent,EditAccountComponent]
})
export class AccountsModule { }
