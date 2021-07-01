import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'http://localhost:52718/api';
  constructor(private http: HttpClient) { }

  register(registerData : any) {
      return this.http.post(this.rootUrl + '/Account/register', registerData);
  }

  login (loginData : any) {
    return this.http.post(this.rootUrl + '/Account/login', loginData);
  }
}
