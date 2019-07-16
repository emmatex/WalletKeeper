import {EventEmitter, Injectable} from '@angular/core';
import {CookieService} from "ngx-cookie-service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private cookies:CookieService) { }

  isLoggedIn():boolean{
    return this.cookies.check('st');
  }
  loggedIn:EventEmitter<any> = new EventEmitter();
  login(){
    this.loggedIn.emit();
  }
}
