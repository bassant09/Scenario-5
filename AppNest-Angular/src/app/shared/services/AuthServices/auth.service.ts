import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import jwt_decode from 'jwt-decode';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  toke: any;
  object: any;
  url: any = environment.ApiUrl + 'Auth/';
  constructor(private _http:HttpClient) { }
  login(data:any): Observable<any> {
   return this._http.post(this.url+'Login',data);
  }
  register(data:any){
    return this._http.post(this.url+"Register",data)
  }
  getToken() {
    return localStorage.getItem('token');
  }
  getTokenPromise(): Promise<string | null> {
    const token = this.getToken();
    console.log(token)
    return Promise.resolve(token || null);
  }
  getDecodedAccessToken() {
    this.toke = this.getToken();
    try {
      this.object = jwt_decode(this.toke);
      console.log(this.object);
      return jwt_decode(this.toke);
    } catch (Error) {
      return null;
    }
  }
}
