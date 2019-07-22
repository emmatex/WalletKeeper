import { Injectable } from '@angular/core';
import {MatSnackBar} from "@angular/material";

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(private snackBar:MatSnackBar) {

  }
  defaultDuration = 300;
  genericError(){
    this.snackBar.open('Something went wrong','close',{duration:this.defaultDuration});
  }
  operationSuccess(){
    this.snackBar.open('Operation completed successfully','close',{duration:this.defaultDuration});
  }
  show(message:string){
    this.snackBar.open(message,'close',{duration:this.defaultDuration});
  }
}
