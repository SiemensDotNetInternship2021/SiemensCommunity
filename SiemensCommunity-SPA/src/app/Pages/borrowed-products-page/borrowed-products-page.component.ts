import { Component, OnInit } from '@angular/core';
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

  borrowedProducts: IBorrowedProducts[] = [];
  categories: ICategory[] = [];
  totalLength:any;
  page:number = 1;
  selectedCategory: number = 0;
  categoryId: number = 0;
  products: IProduct[] = [];
  rating: number = 0;
  userId: number = 0;
  borrowedProductsId: number[]=[];

  constructor(public borrowedProductsService: BorrowedItemsServiceService,
              public categoriesService: CategoriesService,
              public productsService: ProductService) {
    this.borrowedProducts = [];
    this.categories = [];
    this.products = [];
   }

  ngOnInit(): void {
    this.getUserId();
    this.getBorrowedProducts();
    this.getCategories();
    this.getProducts();
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
      }))
  }

  getProducts(){
    this.borrowedProductsService.getAllBorrowedProducts().subscribe((prods) => {
      this.products = [];
      prods.forEach(product => {
        product.detailsList = JSON.parse(product.details);
        this.products.push(product);
      })
    })
  }

  getSelectedCategory(){
    this.categoryId = this.selectedCategory;
    this.getBorrowedProductsByCategoryId();
  }

  getCategories(){
    this.categoriesService.getCategories().subscribe((category) => {
      //category.forEach(value => this.categories.push(value));
      this.categories = category;
    })
  }

  getBorrowedProductsByCategoryId(){
    this.borrowedProductsService.getBorrowedProductsByCategoryId(this.categoryId).subscribe((prodsByCateg) => {
      this.borrowedProducts = prodsByCateg;
    })
  }

}
