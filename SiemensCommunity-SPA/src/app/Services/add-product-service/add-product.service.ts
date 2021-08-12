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

  constructor(private http: HttpClient, private form:FormBuilder) { }
 
    formData = new FormData();
    addProductModel = this.form.group({
    Id: ['', ''],
    Name: ['', Validators.required],
    Category: ['', Validators.required],
    SubCategory : ['', Validators.required],
    Image: ['', Validators.required],
    Properties: ['']
  });

  addProduct(userId: number,properties: any, productId: number, productImage: string) {


    //fill he form to send data in back
    this.formData.append("Id", productId=== undefined? "0": productId.toLocaleString());
    this.formData.append("Name", this.addProductModel.value.Name);
    this.formData.append("CategoryId", this.addProductModel.value.Category);
    this.formData.append("SubCategoryId", this.addProductModel.value.SubCategory);
    this.formData.append("Details", JSON.stringify(properties));
    this.formData.append("UserId", userId.toLocaleString());
    if(productId == undefined || productId == 0){
      return this.http.post(this.rootUrl + '/Product/add', this.formData);
    }else{
      this.formData.append("ImageURL",((productImage === undefined)? "": productImage.toString()));
      return this.http.post(this.rootUrl + '/Product/update', this.formData);
    }
  }


  uploadFile(file: any){
    this.formData.append("Files", file);
  }
}
