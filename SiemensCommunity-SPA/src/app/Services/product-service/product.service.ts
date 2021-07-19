import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IFavoriteProduct } from 'src/app/Models/IFavoriteProduct';
import { IProduct } from 'src/app/Models/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(public http: HttpClient) { }

  getProducts(selectedCategory : number) {
    return this.http.get<IProduct[]>(this.rootUrl + '/Product/' + selectedCategory);
  }

  getFavoriteProducts(userId : number) {
    return this.http.get<IFavoriteProduct[]>(this.rootUrl + '/FavoriteProduct/' + userId);
  }

  addFavoriteProducts(userId : number, productId : number) {
    var favoriteProductDetails = {
      userId : userId,
      productId : productId
    }
    return this.http.post(this.rootUrl + '/FavoriteProduct/', favoriteProductDetails)
  }
}
