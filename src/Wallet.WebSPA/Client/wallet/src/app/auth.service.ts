import {EventEmitter, Injectable} from '@angular/core';
import {CookieService} from "ngx-cookie-service";
import {HttpClientService} from "./http-client.service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private cookies:CookieService,
              private http:HttpClientService) {
    const token = this.cookies.get('st');
    if(token)
      this.http.setToken(token);
  }

  isLoggedIn():boolean{
    return this.cookies.check('st');
  }
  loggedIn:EventEmitter<any> = new EventEmitter();
  login(){
    this.loggedIn.emit();
    const token = this.cookies.get('st');
    this.http.setToken(token);
  }
}
