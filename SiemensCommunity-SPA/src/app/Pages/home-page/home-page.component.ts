import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/Models/IProduct';
import { ProductService } from 'src/app/Services/product-service/product.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  products : IProduct[] = [];

  constructor(public productService: ProductService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts().subscribe((productsFromDb) => 
    {
      this.products = productsFromDb;
      console.log(this.products);
    })
  }

}
