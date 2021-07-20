import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICategory } from 'src/app/Models/ICategory';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  readonly rootUrl = 'https://localhost:44379/api';

  constructor(private http: HttpClient) { }

  getCategories() {
    return this.http.get<ICategory[]>(this.rootUrl + '/Category/get');
  }
}