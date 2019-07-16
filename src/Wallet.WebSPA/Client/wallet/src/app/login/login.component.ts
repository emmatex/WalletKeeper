import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {authenticate} from "../urls";
import {Router} from "@angular/router";
import {CookieService} from "ngx-cookie-service";
import {AuthenticationResponse} from "../domain/models/authenticationResponse.model";
import {AuthService} from "../auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private http: HttpClient, private router: Router, private cookie: CookieService,authService:AuthService) {
    if(authService.isLoggedIn()){
      router.navigate(['/']);
    }
  }

  username: string;
  password: string;
  busy: boolean = false;
  message: string;

  ngOnInit() {
  }

  login() {
    this.busy = true;
    this.message = "";
    this.http.post<AuthenticationResponse>(authenticate(), {
      username: this.username,
      password: this.password
    }).subscribe(value => {
      if (value.isSuccessful) {
        this.cookie.set('st', value.token);
        location.reload();
      } else
        this.message = value.message;
      this.busy = false;
    }, error => {
      if (error.status == 401) {
        this.message = error.error.message;
      } else {
        this.message = "couldn't connect to the api.";
        console.error(error);
      }
      this.busy = false;
    });
  }
}
