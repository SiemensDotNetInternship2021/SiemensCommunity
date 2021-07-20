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
  checkBoxValue : number = 0;
  totalLength:any;
  page : number = 0;
  favoriteProducts : IFavoriteProduct[] =[];
  favoriteProductsId : any[] = [];
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
    this.productService.getProducts(this.selectedCategory, this.checkBoxValue).subscribe((productsFromDb) => 
    {
      this.products = productsFromDb;
      this.totalLength = this.products.length;
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
    this.productService.getProducts(this.selectedCategory, this.checkBoxValue).subscribe((productsFromDb) => 
    {
      this.products = productsFromDb;
    })
  }

  checkboxChange(event : any) {
      this.checkBoxValue = event.target.value;
      console.log(this.checkBoxValue);
      this.productService.getProducts(this.selectedCategory, this.checkBoxValue).subscribe((productsFromDb) => 
    {
      this.products = productsFromDb;
    })
  }

  getFavoriteProducts() {
    this.productService.getFavoriteProducts(this.userId).subscribe((favoriteProductsFromDB) => {
      favoriteProductsFromDB.forEach(value => this.favoriteProductsId.push(value.productId))
      console.log(this.favoriteProductsId);
    })
  }

  addToFavorite(productId : number) {
    this.productService.addFavoriteProduct(productId, this.userId).subscribe((res : any) =>
    {
      this.toastr.success("The product has been added to your favorite list");
      this.favoriteProductsId = [];
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
      this.getFavoriteProducts();
    },
    err=>{
      this.toastr.error("The product couldn`t be removed from your favorite products list");
    });
  }
}
