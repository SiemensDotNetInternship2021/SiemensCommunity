import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProducts } from 'src/app/Models/IProducts';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(private http:HttpClient) { }

  getProducts() {
    return this.http.get<IProducts[]>(this.rootUrl + '/Product/getProducts')
  }
}
