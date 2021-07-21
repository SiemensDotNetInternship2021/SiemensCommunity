import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProduct } from 'src/app/Models/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  readonly rootUrl = 'https://localhost:44379/api';
  constructor(private http: HttpClient) {}

  getProduct(productId: number){
    return this.http.get<IProduct>(this.rootUrl + "/product/getproduct", {params:  {id: productId}});
  }
}
