import { Component, OnInit } from '@angular/core';
import { ICategory } from 'src/app/Models/ICategory';
import { IFavoriteProduct } from 'src/app/Models/IFavoriteProduct';
import { IProduct } from 'src/app/Models/IProduct';
import { CategoryService } from 'src/app/Services/category-service/category.service';
import { ProductService } from 'src/app/Services/product-service/product.service';
import { ToastrService } from 'ngx-toastr';

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
  favoriteProductsId : any[] = [];
  starRating = 0;
  userId = 3;

  constructor(public productService: ProductService,
    public categoryService: CategoryService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getCategories();
    this.getProducts();
    this.getFavoriteProducts();
  }

  getProducts() {
    this.productService.getProducts(this.selectedCategory, this.selectedOption).subscribe((productsFromDb) => 
    {
      this.products = productsFromDb;
    })
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((categoriesFromDb) => 
    {
      this.categories = categoriesFromDb;
    })
  }

  getSelected() {
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
    })
  }

  addFavoriteProduct(productId : number) {
    this.productService.addFavoriteProduct(productId, this.userId).subscribe((res : any) =>
    {
      this.toastr.success("The product has been added to your favorite list");
      this.favoriteProductsId = [];
      this.favoriteProducts =[];
      this.getFavoriteProducts();
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

  rateProduct(productId : number) {
    this.productService.rateProduct(productId, this.userId, this.starRating).subscribe((res : any) =>
    {
      this.toastr.success("The product has been rated");
      this.starRating = 0;
    },
    err=> {
      this.toastr.error("Product couldn`t be rated");
      this.starRating = 0;
    })
  }
}
