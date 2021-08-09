import { Component, OnInit } from '@angular/core';
import { ICategory } from 'src/app/Models/ICategory';
import { IFavoriteProduct } from 'src/app/Models/IFavoriteProduct';
import { IProduct } from 'src/app/Models/IProduct';
import { CategoryService } from 'src/app/Services/category-service/category.service';
import { ProductService } from 'src/app/Services/product-service/product.service';
import { ToastrService } from 'ngx-toastr';
import { BorrowedItemsServiceService } from 'src/app/Services/borrowed-items-service/borrowed-items-service.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  products : IProduct[] = [];
  categories: ICategory[] = [];
  mySelectedCategory : number = 0;
  selectedCategory : number = 0;
  selectedOption : number = 0;
  page : number = 0;
  favoriteProducts : IFavoriteProduct[] =[];
  favoriteProductsId : number[] = [];
  userId : number = 0;
  borrowedProductsId: number[]=[];

  constructor(public productService: ProductService,
    public categoryService: CategoryService,
    private toastr: ToastrService,
    public borrowedProductService: BorrowedItemsServiceService) { }

  ngOnInit(): void {
    this.getUserId()
    this.getCategories();
    this.getProducts();
    this.getFavoriteProducts();
    this.getBorrowedProducts();
  }

  getUserId() {
    var token = localStorage.getItem('token');
    var tokenDetails = "";
    if(token != null) {
      tokenDetails = window.atob(token.split('.')[1]);
    }
      this.userId = parseInt(tokenDetails.split(':')[1].split(',')[0].replace('"', ''));
  }

  getProducts() {
    
    this.productService.getProducts(this.selectedCategory, this.selectedOption).subscribe((productsFromDb) => 
    {
      this.products = [];
      productsFromDb.forEach(product => {
        product.detailsList = JSON.parse(product.details);
        this.products.push(product);
      })
    })
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((categoriesFromDb) => 
    {
      this.categories = categoriesFromDb;
    })
  }

  getSelectedCategory() {
    this.selectedCategory = this.mySelectedCategory;
    this.favoriteProductsId = [];
    this.favoriteProducts = [];
    this.getProducts();
    this.getFavoriteProducts();
  }

  checkboxChange(event : any) {
      this.selectedOption = event.target.value;
      this.favoriteProductsId = [];
      this.favoriteProducts = [];
      this.getProducts();
      this.getFavoriteProducts();
  }

  getFavoriteProducts() {
    this.productService.getFavoriteProducts(this.userId, this.selectedCategory, this.selectedOption).subscribe((favoriteProductsFromDB) => {
      favoriteProductsFromDB.forEach(favoriteProduct => this.favoriteProducts.push(favoriteProduct));
      favoriteProductsFromDB.forEach(favoriteProduct => this.favoriteProductsId.push(favoriteProduct.id))

      this.favoriteProducts = [];

      favoriteProductsFromDB.forEach(favoriteProduct => {
        favoriteProduct.detailsList = JSON.parse(favoriteProduct.details);
        this.favoriteProducts.push(favoriteProduct);
      })
    })
  }

  addFavoriteProduct(productId : number) {
    this.productService.addFavoriteProduct(productId, this.userId).subscribe((res : any) =>
    {
      this.toastr.success("The product has been added to your favorite list");
      this.favoriteProductsId.push(productId);
      this.favoriteProducts =[];
      
    },
    err=>{
      this.toastr.error("The product couldn`t be added to your favorite products list");
    });
  }

  deleteFavoriteProduct(productId : number) {
    this.productService.deleteFavoriteProduct(productId, this.userId).subscribe((res : any) =>
    {
      this.toastr.success("The product has been removed from your favorite list");
      this.favoriteProductsId = [];
      this.favoriteProducts =[];
      this.getFavoriteProducts();
    },
    err=>{
      this.toastr.error("The product couldn`t be removed from your favorite products list");
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

  borrowProduct(productId: number){
    this.borrowedProductService.borrowProduct(productId, this.userId).subscribe((res : any) => 
   {
    this.toastr.success("The product has been borrowed");
    this.borrowedProductsId = [];
     this.getBorrowedProducts();
   },
   err => {
    this.toastr.error("Product couldn`t be borrowed");
   })
  }

  getBorrowedProducts(){
    this.borrowedProductService.getBorrowedProducts(this.userId).subscribe((borrowedProds =>
      {
        borrowedProds.forEach(borrowProd => this.borrowedProductsId.push(borrowProd.id));
      }))
  }

  giveBackBorrowedProduct(productId : number){
    this.borrowedProductService.returnedBorrowedProduct(this.userId, productId).subscribe((res : any) => 
    {
     this.toastr.success("The product has been returned");
     this.borrowedProductsId = [];
     this.getBorrowedProducts();
     this.getProducts();
     this.getFavoriteProducts();
    },
    err => {
     this.toastr.error("Product couldn`t be returned");
    })
  }
}
