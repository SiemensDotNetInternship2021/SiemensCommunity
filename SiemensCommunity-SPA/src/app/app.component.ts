import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'SiemensCommunity-SPA';
  products: any;

  constructor(private http: HttpClient)
  {

  }

  ngOnInit() 
  {
    this.http.get("http://localhost:52718/api/Product/get").subscribe(response => {
      this.products = response;
    }, error => {
      console.log(error);
    });
  }

}
