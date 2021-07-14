import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProduct } from 'src/app/Models/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(public http: HttpClient) { }

  getProducts() {
    return this.http.get<IProduct[]>(this.rootUrl + '/Product/get');
  }
}
