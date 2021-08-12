import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IFavoriteProduct } from 'src/app/Models/IFavoriteProduct';
import { IProduct } from 'src/app/Models/IProduct';
import { DatePipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(public http: HttpClient,
              public date: DatePipe) { }

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

  getProduct(productId: number){
    return this.http.get<IProduct>(this.rootUrl + "/product/getproduct", {params:  {id: productId}});
  }

  getAllProducts() {
    return this.http.get<IProduct[]>(this.rootUrl + '/Product/getProductsList');
  }

  getUserProducts(userId: number, selectedCategoryId?: any) {
    if(selectedCategoryId == null)
      return this.http.get<IProduct[]>(this.rootUrl + '/Product/getUserProducts?userId=' + userId);
    else
      return this.http.get<IProduct[]>(this.rootUrl + '/Product/getUserProducts?userId=' + userId + "&categoryId=" +selectedCategoryId);
  }

  getUserAvailableProducts(userId: number, selectedCategoryId?: any){
    if(selectedCategoryId == null)
      return this.http.get<IProduct[]>(this.rootUrl + '/Product/getUserAvailableProducts?userId=' + userId);
    else
      return this.http.get<IProduct[]>(this.rootUrl + '/Product/getUserAvailableProducts?userId=' + userId + "&categoryId=" +selectedCategoryId);
  }

  getUserLendProducts(userId: number, selectedCategoryId?: any){
    if(selectedCategoryId == null)
      return this.http.get<IProduct[]>(this.rootUrl + '/Product/getUserLendProducts?userId=' + userId);
    else
      return this.http.get<IProduct[]>(this.rootUrl + '/Product/getUserLendProducts?userId=' + userId + "&categoryId=" +selectedCategoryId);
  }


  deleteProduct(productId: any){
    return this.http.delete<boolean>(this.rootUrl + "/product/delete?id=" + productId);
  }
}
