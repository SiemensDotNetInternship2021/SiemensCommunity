import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBorrowedProducts } from 'src/app/Models/IBorrowedProducts';
import { IProduct } from 'src/app/Models/IProduct';

@Injectable({
  providedIn: 'root'
})
export class BorrowedItemsServiceService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(private http: HttpClient,
              public date : DatePipe) { }

  getBorrowedProducts(userId: number) {
    return this.http.get<IBorrowedProducts[]>(this.rootUrl + '/BorrowedProduct/getBorrowedProducts?userId=' + userId);
  } 

  getBorrowedProductsByCategoryId(userId: number, category: number) {
    return this.http.get<IBorrowedProducts[]>(this.rootUrl + '/BorrowedProduct/getBorrowedProductsByCategory?userId=' +userId+'&categoryId=' + category);
  }

  // getAllBorrowedProducts() {
  //   return this.http.get<IProduct[]>(this.rootUrl + '/Product/getProducts')
  // }

  borrowProduct(productId: number, userId: number) {

    var date = new Date();
    var currentDate = this.date.transform(date, 'yyyy/mm/dd')
    var endDate = new Date();
    endDate.setDate(date.getDate() + 14);

    var borrowDetails = {
      productId: productId,
      userId: userId,
      startDate: new Date().toISOString(),
      endDate: endDate.toISOString()
    }

    console.log(borrowDetails.productId + " " + borrowDetails.userId + " " +  borrowDetails.startDate + " " +  borrowDetails.endDate);
    return this.http.post(this.rootUrl + '/BorrowedProduct/borrowProduct', borrowDetails);
  }

  returnedBorrowedProduct(userId: number, productId: number) {
    var borrowDetails = {
      userId: userId,
      productId: productId
    }

    return this.http.post(this.rootUrl + '/BorrowedProduct/returnBorrowedProduct', borrowDetails);
  }
}
