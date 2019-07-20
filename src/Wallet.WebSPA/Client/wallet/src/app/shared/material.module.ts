import {NgModule} from "@angular/core";

import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {
  MatButtonModule, MatButtonToggleModule,
  MatCardModule, MatCheckboxModule, MatDialogModule,
  MatDividerModule, MatExpansionModule, MatFormFieldModule,
  MatIconModule, MatInputModule, MatListModule, MatMenuModule, MatProgressBarModule, MatSelectModule,
  MatSidenavModule, MatSnackBarModule, MatSortModule, MatTableModule,
  MatToolbarModule, MatTooltipModule
} from "@angular/material";

@NgModule({
  imports: [
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    MatIconModule,
    MatListModule,
    MatExpansionModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonToggleModule,
    MatDialogModule,
    MatSnackBarModule,
    MatProgressBarModule,
    MatSelectModule,
    MatMenuModule,
    MatCheckboxModule,
    MatTooltipModule
  ],
  exports:[
    MatMenuModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    MatIconModule,
    MatListModule,
    MatExpansionModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonToggleModule,
    MatDialogModule,
    MatSnackBarModule,
    MatProgressBarModule,
    MatSelectModule,
    MatCheckboxModule,
    MatTooltipModule
  ]
})
export class MaterialModule { }
