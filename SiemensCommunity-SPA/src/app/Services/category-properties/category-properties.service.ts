import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProperty } from 'src/app/Models/IProperty';

@Injectable({
  providedIn: 'root'
})
export class CategoryPropertiesService {

  readonly rootUrl = 'https://localhost:44379/api';
  public categoryProperties: IProperty[] = [];

  constructor(private http: HttpClient) { }

  getCategoryProperties(categoryId: any){
    return this.http.get<IProperty[]>(this.rootUrl + "/property/getCategoryProperties", {
       params: 
        {categoryId: categoryId},
      observe: 'response'});
  }

}
