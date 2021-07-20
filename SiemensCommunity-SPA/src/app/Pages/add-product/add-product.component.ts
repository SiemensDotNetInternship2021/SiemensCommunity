import { JsonPipe } from '@angular/common';
import { ɵflushModuleScopingQueueAsMuchAsPossible } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FileUploader } from 'ng2-file-upload';
import { ToastrComponentlessModule, ToastrService } from 'ngx-toastr';
import { ICategory } from 'src/app/Models/ICategory';
import { IProperty } from 'src/app/Models/IProperty';
import { ISubCategory } from 'src/app/Models/ISubCategory';
import { AddProductService } from 'src/app/Services/add-product-service/add-product.service';
import { CategoryPropertiesService } from 'src/app/Services/category-properties/category-properties.service';
import { CategoryService } from 'src/app/Services/category-service/category.service';
import { SubcategoryService } from 'src/app/Services/subcategory-service/subcategory.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {



  categories : ICategory[] = [];
  selectedCategoryId: number = 0;
  selectedCategories: ICategory[] = [];

  subcategories: ISubCategory[] = [];
  selectedSubCategory: any;
  selectedSubCategoryId: number = 0;
  selectedSubCategories: ISubCategory[] = [];

  properties: IProperty[] = [];
  photo: any;

  titlePage: string = "";
  sendButtonTile: string = "";
  saveSuccess: boolean = false;

  constructor(public service: AddProductService, 
    public categoryService: CategoryService,
    public subcategoryService: SubcategoryService,
    public categoryPropertiesService: CategoryPropertiesService,
    public router: Router,
    public toastr: ToastrService) { }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe((category) => {
      category.forEach(value => this.categories.push(value));
    });
    this.selectedCategories = this.categories;

    this.subcategoryService.getSubCategories().subscribe((subcategory)=>{
      subcategory.forEach(value => this.subcategories.push(value));
    }); 
    this.selectedSubCategories = this.subcategories;

    this.titlePage = "Add new product";
  }

  getProperties(selectedCategoryId: any){
    this.properties = [];
    this.categoryPropertiesService.getCategoryProperties(selectedCategoryId).subscribe(res => {
      if(res.body!= null)
        this.properties = res.body;
    });
  }

  addProduct() {
    console.log();
    this.service.addProduct(this.properties).subscribe((res: any) => 
    {
      alert("Product added succsefully.");
      this.router.navigateByUrl('/home');
    },
    err =>{
      this.toastr.error("error");
    });
  }

  onCategoryChanged(selectedCategoryId: any){
    this.selectedCategoryId = selectedCategoryId;
    this.selectedSubCategories = [];
    this.subcategories.forEach(subcategory => {
      if(subcategory.categoryId == selectedCategoryId){
        this.selectedSubCategories.push(subcategory);
      }
    });
    this.getProperties(selectedCategoryId);
  }

  onSubCategoryChanged(selectedSubCategoryId: any){
    this.selectedSubCategoryId = selectedSubCategoryId;
    this.selectedSubCategories.forEach(subcategory => {
      if(subcategory.id == selectedSubCategoryId){
        this.selectedSubCategory = subcategory;
      }
    });

    if(this.selectedCategoryId == 0){
      this.selectedCategories = [];
      this.categories.forEach(category => {
        if(category.id == this.selectedSubCategory.id){
          this.selectedCategories.push(category);
        }
      });
    }
  }

  onFileSelect(event: any){
    console.log(typeof(event) );
    this.service.uploadFile(event);
  }
}
