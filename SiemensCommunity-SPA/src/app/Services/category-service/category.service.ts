import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICategory } from 'src/app/Models/ICategory';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(public http: HttpClient) { }
  
  getCategories() {
    return this.http.get<ICategory[]>(this.rootUrl + '/Category/get')
  }
}