import { isGeneratedFile } from '@angular/compiler/src/aot/util';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ICategory } from 'src/app/Models/ICategory';
import { IProduct } from 'src/app/Models/IProduct';
import { CategoriesService } from 'src/app/Services/categories-service/categories.service';
import { ProductService } from 'src/app/Services/product-service/product.service';

@Component({
  selector: 'app-mycatalog-page',
  templateUrl: './mycatalog-page.component.html',
  styleUrls: ['./mycatalog-page.component.css']
})
export class MycatalogPageComponent implements OnInit {
  
  products : IProduct[] = [];
  categories: ICategory[] = [];
  mySelectedCategory : number = 0;
  selectedOption : number = 0;
  page : any;
  userId : number = 0;
  mySelectedOption: number= 0;

  constructor(private productService: ProductService,
   private toastr: ToastrService,
   private categoryService: CategoriesService) { }

  ngOnInit(): void {
    this.getCategories();
    this.getUserId();
    this.getMyCatalogProducts(0, null);
  }


  //get user id form token
  getUserId() {
    var token = localStorage.getItem('token');
    var tokenDetails: any;
    if(token != null) {
     tokenDetails = window.atob(token.split('.')[1]);
     tokenDetails = JSON.parse(tokenDetails);
     this.userId = tokenDetails.UserId;
    }
  }

  getProducts() {
    console.log(this.userId);
    this.productService.getUserProducts(this.userId, this.mySelectedCategory).subscribe((productsFromDb) => 
    {
      this.products = [];
      productsFromDb.forEach(product =>{
        product.detailsList = JSON.parse(product.details);
        this.products.push(product);
      })
      console.log(this.products);
    })
  }

  checkboxChange(event: any){
    this.selectedOption = event.target.value;
    this.getMyCatalogProducts(this.selectedOption, (this.mySelectedCategory == 0)? null:this.mySelectedCategory);
  }

  onCategoryChanged(){
    this.getMyCatalogProducts(this.selectedOption, this.mySelectedCategory);
  }

  getMyCatalogProducts(optionValue: any, selectedCategory: any){
    if(selectedCategory == 0){
      selectedCategory = null;
    }
    if(optionValue == 0){
      this.productService.getUserProducts(this.userId, selectedCategory).subscribe(products =>{
        this.products = products;
      });
    }else if(optionValue == 1){
      this.productService.getUserAvailableProducts(this.userId, selectedCategory).subscribe(products =>{
        this.products = products;
      });

    }else if(optionValue == 2){
      this.productService.getUserLendProducts(this.userId, selectedCategory).subscribe(products =>{
        this.products = products;
        console.log(this.products);
      });
    }
  }

  deleteProduct(productId: number){
    this.productService.deleteProduct(productId).subscribe((res : any) =>
    {
      this.toastr.success("Product deleted successfully");
      this.getMyCatalogProducts(this.selectedOption, this.mySelectedCategory);
    },
    err=>{
      this.toastr.error("The product could not be deleted");
    })
  }

  getCategories(){
    this.categoryService.getCategories().subscribe(categories =>{
      this.categories = categories;
    });
  }

}
