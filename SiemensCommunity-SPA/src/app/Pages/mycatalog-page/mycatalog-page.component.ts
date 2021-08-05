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
  mySelectedOption: any;

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
    this.userId = 2;
    if(token != null) {
     // tokenDetails = window.atob(token.split('.')[1]);
    }
      //this.userId = parseInt(tokenDetails.split(':')[1].split(',')[0].replace('"', ''));
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
    console.log("kkkkkkkkk");
    this.getMyCatalogProducts(this.selectedOption, this.mySelectedCategory);
  }

  getMyCatalogProducts(optionValue: any, selectedCategory: any){
    if(optionValue == 0){
      this.productService.getUserProducts(this.userId, selectedCategory).subscribe(products =>{
        this.products = products;
      });
    }else if(optionValue == 1){
      this.productService.getUserAvailableProducts(this.userId, selectedCategory).subscribe(products =>{
        this.products = products;
      });

    }else if(optionValue == 2){
      this.productService.getUserLentedProducts(this.userId, selectedCategory).subscribe(products =>{
        this.products = products;
        console.log(this.products);
        console.log(products);
      });
    }
  }

  deleteProduct(productId: number){
    this.productService.deleteProduct(productId).subscribe((res : any) =>
    {
      this.toastr.success("Product deleted successfully");
      this.getProducts();
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
