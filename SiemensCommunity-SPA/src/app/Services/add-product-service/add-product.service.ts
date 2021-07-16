import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup, AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ICategory } from 'src/app/Models/ICategory';

@Injectable({
  providedIn: 'root'
})
export class AddProductService {

  readonly rootUrl = 'http://localhost:52718/api';

  constructor(private http: HttpClient, private form:FormBuilder,) { }
 
  addProductModel = this.form.group({
    Id: ['', ''],
    Name: ['', Validators.required],
    Category: ['', Validators.required],
    SubCategory : ['', Validators.required],
    ImagePath : ['',  Validators.required],
    Details : ['', Validators.required]
});
  addProduct() {
    var addProductData = {
      Id: this.addProductModel.value.Id,
      Name: this.addProductModel.value.Name,
      CategoryId: this.addProductModel.value.Category,
      SubCategoryId: this.addProductModel.value.SubCategory,
      ImagePath: this.addProductModel.value.ImagePath,
      Details: this.addProductModel.value.Details,
      UserId: 1
    }
    console.log(addProductData);
    if(addProductData.Id == 0){
        return this.http.post(this.rootUrl + '/Product/add', addProductData);
    }else{
      return this.http.post(this.rootUrl+'/Product/update',  addProductData);
    }
  }

  getCategories(){
    return this.http.get<ICategory[]>(this.rootUrl + '/Category/get')
  }
}
