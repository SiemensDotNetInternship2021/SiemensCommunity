import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'http://localhost:52718/api';
  constructor(private http: HttpClient) { }
  register(formData : any) {
      return this.http.post(this.rootUrl + '/Account/register', formData);
  }
}
