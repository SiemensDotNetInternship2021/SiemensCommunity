import { Component, OnInit } from '@angular/core';
import { ICategory } from 'src/app/Models/ICategory';
import { IProduct } from 'src/app/Models/IProduct';
import { CategoryService } from 'src/app/Services/category-service/category.service';
import { ProductService } from 'src/app/Services/product-service/product.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  products : IProduct[] = [];
  categories: ICategory[] = [];
  mySelect : number = 0;
  selectedValue : number = 0;
  checkBoxValue : number = 0;

  constructor(public productService: ProductService,
    public categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getCategories();
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts(this.selectedValue).subscribe((productsFromDb) => 
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
    this.selectedValue = this.mySelect;
    this.productService.getProducts(this.selectedValue).subscribe((productsFromDb) => 
    {
      this.products = productsFromDb;
    })
  }

  checkboxChange(event : any) {
      this.checkBoxValue = event.target.value;
      console.log(this.checkBoxValue);
  }

}
