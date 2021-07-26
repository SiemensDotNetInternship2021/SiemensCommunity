import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CheckboxControlValueAccessor } from '@angular/forms';
import { IFavoriteProduct } from 'src/app/Models/IFavoriteProduct';
import { IOptionDetails } from 'src/app/Models/IOptionDetails';
import { IProduct } from 'src/app/Models/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(public http: HttpClient) { }

  getProducts(selectedCategory : number, selectedOption : number) {
    var optionDetails  = {
      selectedCategory : selectedCategory,
      selectedOption : selectedOption
    }
   return this.http.get<IProduct[]>(this.rootUrl + '/Product/optionDetails?selectedCategory=' + selectedCategory + '&&selectedOption=' + selectedOption);
  }

  getFavoriteProducts(userId : number, selectedCategory : number, selectedOption : number) {
    return this.http.get<IFavoriteProduct[]>(this.rootUrl + '/FavoriteProduct/favoriteProductDetails?userId=' + userId + '&selectedCategory=' + selectedCategory + '&selectedOption=' + selectedOption);
  }

  addFavoriteProduct(productId : number, userId : number) {
    var favoriteProductDetails = {
      userId : userId,
      productId : productId
    }
    return this.http.post(this.rootUrl + '/FavoriteProduct/', favoriteProductDetails)
  }

  deleteFavoriteProduct(productId : number, userId : number) {
    var favoriteProductDetails = {
      userId : userId,
      productId : productId,
    }
    return this.http.post(this.rootUrl + '/FavoriteProduct/DeleteFavoriteProduct' , favoriteProductDetails)
  }

  rateProduct(productId : number, userId : number, event : number) {
    var ratingDetails = {
      productId : productId,
      userId : userId,
      rate : event,
    }

    return this.http.post(this.rootUrl + '/ProductRating/', ratingDetails)
  }
}
