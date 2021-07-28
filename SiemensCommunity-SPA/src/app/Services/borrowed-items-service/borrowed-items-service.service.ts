import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBorrowedProducts } from 'src/app/Models/IBorrowedProducts';

@Injectable({
  providedIn: 'root'
})
export class BorrowedItemsServiceService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(private http: HttpClient) { }

  getBorrowedProducts() {
    return this.http.get<IBorrowedProducts[]>(this.rootUrl + '/BorrowedProduct/getBorrowedProducts')
  } 

  getBorrowedProductsByCategoryId(category: number) {
    return this.http.get<IBorrowedProducts[]>(this.rootUrl + '/BorrowedProduct/getBorrowedProductsByCategory?categoryId=' + category);
  }
}
