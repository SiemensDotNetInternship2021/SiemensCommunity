import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup, AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AnonymousSubject } from 'rxjs/internal/Subject';
import { ICategory } from 'src/app/Models/ICategory';
import { IProperty } from 'src/app/Models/IProperty';

@Injectable({
  providedIn: 'root'
})
export class AddProductService {

  readonly rootUrl = 'http://localhost:52718/api';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token' // if you have one
    })
  };
  constructor(private http: HttpClient, private form:FormBuilder,) { }
  addProductModel = this.form.group({
    Id: ['', ''],
    Name: ['', Validators.required],
    Category: ['', Validators.required],
    SubCategory : ['', Validators.required],
    Image: ['', Validators.required],
  });

  addProduct(properties: any) {
    var addProductData = {
      Id: this.addProductModel.value.Id,
      Name: this.addProductModel.value.Name,
      CategoryId: this.addProductModel.value.Category,
      SubCategoryId: this.addProductModel.value.SubCategory,
      Image: this.addProductModel.value.Image,
      Details: JSON.stringify(properties),
      UserId: 1
    }
    console.log("imagineee " + JSON.stringify(this.addProductModel.value.Image) );
    if(addProductData.Id != 0){
      console.log("in");
      return this.http.post(this.rootUrl+'/Product/update',  addProductData, this.httpOptions);
    }else{
      addProductData.Id = 0;
      console.log(addProductData);
      return this.http.post(this.rootUrl + '/Product/add', addProductData);
    }
  }

  getCategories(){
    return this.http.get<ICategory[]>(this.rootUrl + '/Category/get')
  }
  uploadFile(file: any){
    this.addProductModel.value.Image.append(file);
    console.log(this.addProductModel.value.Image);
    // console.log(file + " in service");
    // this.addProductModel.value.Image = file;
    // console.log("after service" + this.addProductModel.value.Image);
  }
}
