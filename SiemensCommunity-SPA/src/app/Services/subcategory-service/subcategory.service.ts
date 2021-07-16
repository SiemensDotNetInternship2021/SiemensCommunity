import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISubCategory } from 'src/app/Models/ISubCategory';

@Injectable({
  providedIn: 'root'
})
export class SubcategoryService {

  readonly rootUrl = 'http://localhost:52718/api';
  constructor(private http: HttpClient) { }

  getSubCategories(){
    return this.http.get<ISubCategory[]>(this.rootUrl + '/SubCategory/get');
  }
}
