import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {authenticate} from "../urls";
import {catchError} from "rxjs/operators";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private http:HttpClient) {
  }

  username: string;
  password: string;
  busy: boolean=false;
  message:string;
  ngOnInit() {
  }

  login() {
    this.busy = true;
    this.message = "";
    this.http.post(authenticate(),{username:this.username,password:this.password}).subscribe(value => {
      console.log(value);
      this.busy = false;
    },error=>{
      if(error.status ==401){
        this.message = error.error.message;
      }
      else{
        this.message = "couldn't connect to the api.";
        console.error(error);
      }
      this.busy = false;

    });
  }
}
