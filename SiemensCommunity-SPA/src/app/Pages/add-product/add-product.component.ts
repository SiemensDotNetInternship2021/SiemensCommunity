import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrComponentlessModule, ToastrService } from 'ngx-toastr';
import { ICategory } from 'src/app/Models/ICategory';
import { IProperty } from 'src/app/Models/IProperty';
import { ISubCategory } from 'src/app/Models/ISubCategory';
import { AddProductService } from 'src/app/Services/add-product-service/add-product.service';
import { CategoryPropertiesService } from 'src/app/Services/category-properties/category-properties.service';
import { CategoryService } from 'src/app/Services/category-service/category.service';
import { ProductService } from 'src/app/Services/product-service/product.service';
import { SubcategoryService } from 'src/app/Services/subcategory-service/subcategory.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  categories : ICategory[] = [];
  category: ICategory= {id: 0, name: "", isSelected: ""};
  selectedCategoryId: number = 0;
  selectedCategories: ICategory[] = [];
  isSelectedCategory: string = "selected";

  subcategories: ISubCategory[] = [];
  selectedSubCategory: any;
  selectedSubCategoryId: number = 0;
  selectedSubCategories: ISubCategory[] = [];
  isSelectedSubCategory: string = "selected";

  properties: IProperty[] = [];
  photo: any;

  titlePage: string = "";
  sendButtonTile: string = "";
  saveSuccess: boolean = false;

  productId: number = 0;
  productImage: string = '';

  constructor(public service: AddProductService, 
    public categoryService: CategoryService,
    public subcategoryService: SubcategoryService,
    public categoryPropertiesService: CategoryPropertiesService,
    public productService: ProductService,
    public router: Router,
    public route: ActivatedRoute,
    public toastr: ToastrService) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params =>{
      this.productId = params['id'];
    });
    if(this.productId == undefined){
      this.addProductPageConstructor();
    }else{
      this.modifyProductConstructor(this.productId);
    }
  }
//builds the page to add a new product
  addProductPageConstructor(){
    this.getCategories();
    this.getSubCategories();  
    this.titlePage = "Add new product";
  }

  //build the page o edit a product 
  modifyProductConstructor(productId: number){
    console.log("componenta product id " + productId);
    this.productService.getProduct(productId).subscribe((product) =>{
      console.log(product);
      this.fillForm(product);
    });
  }

  //fiil the form un the product data
  fillForm(product: any){
    console.log(product.details);
    this.properties =JSON.parse(product.details);
    console.log(this.properties);
    this.service.addProductModel.value.Name = product.name;
    this.service.addProductModel.controls['Name'].setValue(product.name);
    this.properties = JSON.parse(product.details);
    this.properties.forEach(property => {
      console.log(property.description);
    });
    this.getCategories();
    this.getSubCategories();
    this.service.addProductModel.controls['Category'].setValue(product.category.id);
    this.service.addProductModel.controls['SubCategory'].setValue(product.subcategory.id);
    this.productImage = product.photo;
    console.log(product);
    console.log(this.service.addProductModel.value.Image);
    this.selectedSubCategoryId = product.subcategory.id;
  }

  //get all categories from db
  getCategories(){
    this.categoryService.getCategories().subscribe((item) => {
      item.forEach(value =>{
        this.categories.push(value)
      });
    });
    this.selectedCategories = this.categories;
  }

  //get subcategories from db
  getSubCategories(){
    this.subcategoryService.getSubCategories().subscribe((subcategory)=>{
      subcategory.forEach(value => this.subcategories.push(value));
      this.selectedSubCategories = this.subcategories;
    }); 
  }
  
  //call api
  addProduct() {
    this.service.addProduct(this.properties, this.productId, this.productImage).subscribe((res: any) => 
    {
      this.toastr.success("Product added succsefully.");
      this.router.navigateByUrl('/home');
    },
    err =>{
      this.toastr.error("error");
    });
  }

  //when category changed fiil subcategories and properties
  onCategoryChanged(selectedCategoryId: any){
    this.selectedCategoryId = selectedCategoryId;
    this.selectedSubCategories = [];
    this.subcategories.forEach(subcategory => {
      if(subcategory.categoryId == selectedCategoryId){
        this.selectedSubCategories.push(subcategory);
      }
    });
    console.log(this.productId);
    if(this.productId == undefined){
      if(typeof(selectedCategoryId) == 'string' || typeof(selectedCategoryId) == 'number'){
        this.getProperties(selectedCategoryId);
      }
      else {
        this.getProperties(selectedCategoryId.id);
      }
    }
  }

  //when a subcategory has been changed
  onSubCategoryChanged(selectedSubCategoryId: any){
    console.log("in subcategory changed")
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

  //get properties of a category
  getProperties(selectedCategoryId: any){
    this.properties = [];
    this.categoryPropertiesService.getCategoryProperties(selectedCategoryId).subscribe(res => {
      res.forEach(property =>{
        this.properties.push(property);
      })
    });
  }


  //upload file in form
  onFileSelect(event: any){
    if (event.target.files.length > 0) {
    var file = event.target.files[0];
    this.service.uploadFile(file);
    }
  }

  onInputChange(event: any, propertyId: number){
    this.properties.forEach(property =>{
      if(property.id == propertyId){
        property.description = event.target.value;
      }
    })
  }
}
