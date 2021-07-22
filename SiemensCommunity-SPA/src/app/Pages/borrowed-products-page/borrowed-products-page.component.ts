import { Component, OnInit } from '@angular/core';
import { IBorrowedProducts } from 'src/app/Models/IBorrowedProducts';
import { BorrowedItemsServiceService } from 'src/app/Services/borrowed-items-service/borrowed-items-service.service';

@Component({
  selector: 'app-borrowed-products-page',
  templateUrl: './borrowed-products-page.component.html',
  styleUrls: ['./borrowed-products-page.component.css']
})
export class BorrowedProductsPageComponent implements OnInit {

  borrowedProducts: IBorrowedProducts[] = [];
  totalLength:any;
  page:number = 1;

  constructor(public borrowedProductsService: BorrowedItemsServiceService) {
    this.borrowedProducts = [];
   }

  ngOnInit(): void {
    this.getBorrowedProducts();
  }

  getBorrowedProducts(){
    this.borrowedProductsService.getBorrowedProducts().subscribe((borrowedProds =>
      {
        this.borrowedProducts = borrowedProds;
        this.totalLength = this.borrowedProducts.length;
      }))
  }

}
