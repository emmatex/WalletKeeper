import { NgModule } from '@angular/core';
import {
  MatButtonModule, MatCardModule,
  MatDialogModule, MatExpansionModule, MatFormFieldModule,
  MatIconModule,
  MatInputModule, MatListModule,
  MatMenuModule, MatProgressBarModule, MatSelectModule, MatSnackBarModule, MatTableModule,
  MatToolbarModule
} from "@angular/material";
import {FormsModule} from "@angular/forms";
import {DeleteConfirmationComponent} from "../delete-confirmation/delete-confirmation.component";
import {HttpClientModule} from "@angular/common/http";
import {MaterialModule} from "./material.module";



@NgModule({
  declarations: [DeleteConfirmationComponent],
  imports: [
    FormsModule,
    HttpClientModule,
    MaterialModule
  ],
  exports:[
    FormsModule,
    HttpClientModule,
    MaterialModule
  ]
})
export class SharedModule { }
