import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup, AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
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

  addProduct(properties: any, productId: number, productImage: string) {
    var addProductData = {
      Id: ((this.addProductModel.value.Id == 0)? 0: this.addProductModel.value.Id),
      Name: this.addProductModel.value.Name,
      CategoryId: this.addProductModel.value.Category,
      SubCategoryId: this.addProductModel.value.SubCategory,
      Image: this.addProductModel.value.Image,
      Details: properties,
      UserId: 1
    }
    this.formData.append("Id", productId=== undefined? "": productId.toLocaleString());
    this.formData.append("Name", this.addProductModel.value.Name);
    this.formData.append("CategoryId", this.addProductModel.value.Category);
    this.formData.append("SubCategoryId", this.addProductModel.value.SubCategory);
    this.formData.append("Details", JSON.stringify(properties));
    console.log(productImage);
    this.formData.append("UserId", "1");
    if(productId == undefined){
      return this.http.post(this.rootUrl + '/Product/add', this.formData);
    }else{
      this.formData.append("ImageURL",((productImage === undefined)? "": productImage.toString()));
      return this.http.post(this.rootUrl + '/Product/update', this.formData);
    }
  }

  getCategories(){
    return this.http.get<ICategory[]>(this.rootUrl + '/Category/get')
  }

  uploadFile(file: any){
    this.formData.append("Files", file);
  }
}
