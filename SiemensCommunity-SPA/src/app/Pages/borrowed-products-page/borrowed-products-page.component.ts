import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IBorrowedProducts } from 'src/app/Models/IBorrowedProducts';
import { ICategory } from 'src/app/Models/ICategory';
import { IProduct } from 'src/app/Models/IProduct';
import { BorrowedItemsServiceService } from 'src/app/Services/borrowed-items-service/borrowed-items-service.service';
import { CategoriesService } from 'src/app/Services/categories-service/categories.service';
import { ProductService } from 'src/app/Services/product-service/product.service';


@Component({
  selector: 'app-borrowed-products-page',
  templateUrl: './borrowed-products-page.component.html',
  styleUrls: ['./borrowed-products-page.component.css']
})
export class BorrowedProductsPageComponent implements OnInit {

  borrowedProducts: IProduct[] = [];
  categories: ICategory[] = [];
  totalLength:any;
  page:number = 1;
  selectedCategory: number = 0;
  categoryId: number = 0;
  products: IProduct[] = [];
  rating: number = 0;
  userId: number = 0;

  constructor(public borrowedProductsService: BorrowedItemsServiceService,
              public categoriesService: CategoriesService,
              private toastr: ToastrService,
              private productService: ProductService) {
    this.borrowedProducts = [];
    this.categories = [];
    this.products = [];
   }

  ngOnInit(): void {
    this.getUserId();
    this.getCategories();
    this.getProducts(this.categoryId);
    //    this.getProducts();
  }

  getUserId() {
    var token = localStorage.getItem('token');
    var tokenDetails = "";
    if(token != null) {
      tokenDetails = window.atob(token.split('.')[1]);
    }
      this.userId = parseInt(tokenDetails.split(':')[1].split(',')[0].replace('"', ''));
  }

  getBorrowedProducts(){
    this.borrowedProductsService.getBorrowedProducts(this.userId).subscribe((borrowedProds =>
      {
        this.borrowedProducts = borrowedProds;
        this.totalLength = this.borrowedProducts.length;
        console.log(borrowedProds);
      }));
      console.log(this.borrowedProducts);
  }

  // getProducts(){
  //   this.borrowedProductsService.getAllBorrowedProducts().subscribe((prods) => {
  //     this.products = prods;
  //   })
  // }

  getSelectedCategory(){
    this.categoryId = this.selectedCategory;
    this.getProducts(this.categoryId);
  }

  getProducts(categoryId: number){
    if(categoryId == 0){
      this.getBorrowedProducts();
    }else{
        this.getBorrowedProductsByCategoryId(this.userId, this.categoryId);
    }
    console.log(this.borrowedProducts);
  }

  getCategories(){
    this.categoriesService.getCategories().subscribe((category) => {
      //category.forEach(value => this.categories.push(value));
      this.categories = category;
    })
  }

  getBorrowedProductsByCategoryId(userId: number, categoryId: number){
    this.borrowedProductsService.getBorrowedProductsByCategoryId(userId, categoryId).subscribe((prodsByCateg) => {
      this.borrowedProducts = prodsByCateg;
    })
  }

  giveBackProduct(productId: number){
    console.log(productId);
    this.borrowedProductsService.returnedBorrowedProduct(this.userId, productId).subscribe((res) =>
      {
        this.toastr.success("The product has been returned.");
        console.log("aaaaaaaaaaaaaaa");
        this.getProducts(this.categoryId);
      },
      err=>{
        this.toastr.error("The product could not be returned .");
      });
  }

  rateProduct(productId : number, event : number) {
    this.productService.rateProduct(productId, this.userId, event).subscribe((res : any) =>
    {
      this.toastr.success("The product has been rated");
    },
    err=> {
      this.toastr.error("Product couldn`t be rated");
    })
  }
}
