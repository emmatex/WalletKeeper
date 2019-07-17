import {Injectable} from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private http: HttpClient) {
  }

  private _token: string;

  setToken(token: string) {
    this._token = token;
  }

  get<T>(url: string, param: HttpParams = null): Observable<T> {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    if (this._token)
      headers = headers.set("Authorization", `Bearer ${this._token}`);
    return this.http.get<T>(url, {params: param, headers: headers});
  }

  post<T>(url: string, param: any): Observable<T> {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    if (this._token)
      headers = headers.set("Authorization", `Bearer ${this._token}`);
    return this.http.post<T>(url, param, {headers: headers});
  }
}
