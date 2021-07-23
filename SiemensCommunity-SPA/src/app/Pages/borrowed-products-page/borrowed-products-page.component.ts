import { Component, OnInit } from '@angular/core';
import { IBorrowedProducts } from 'src/app/Models/IBorrowedProducts';
import { ICategory } from 'src/app/Models/ICategory';
import { BorrowedItemsServiceService } from 'src/app/Services/borrowed-items-service/borrowed-items-service.service';
import { CategoriesService } from 'src/app/Services/categories-service/categories.service';


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

  constructor(public borrowedProductsService: BorrowedItemsServiceService,
              public categoriesService: CategoriesService) {
    this.borrowedProducts = [];
    this.categories = [];
   }

  ngOnInit(): void {
    this.getBorrowedProducts();
    this.getCategories();
  }

  getBorrowedProducts(){
    this.borrowedProductsService.getBorrowedProducts().subscribe((borrowedProds =>
      {
        this.borrowedProducts = borrowedProds;
        this.totalLength = this.borrowedProducts.length;
      }))
  }

  getCategories(){
    this.categoriesService.getCategories().subscribe((category) => {
      category.forEach(value => this.categories.push(value));
    })
  }

}
