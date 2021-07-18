import { ɵflushModuleScopingQueueAsMuchAsPossible } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ICategory } from 'src/app/Models/ICategory';
import { ISubCategory } from 'src/app/Models/ISubCategory';
import { AddProductService } from 'src/app/Services/add-product-service/add-product.service';
import { CategoryService } from 'src/app/Services/category-service/category.service';
import { SubcategoryService } from 'src/app/Services/subcategory-service/subcategory.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  categories : ICategory[] = [];
  selectedCategory: number = 0;
  subcategories: ISubCategory[] = [];
  selectedSubCategory: number = 0;
  titlePage: string = "";
  sendButtonTile: string = "";
  saveSuccess: boolean = false;

  constructor(public service: AddProductService, 
    public categoryService: CategoryService,
    public subcategoryService: SubcategoryService,
    public router: Router,
    public toastr: ToastrService) { }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe((category) => {
      category.forEach(value => this.categories.push(value));
    });

    this.subcategoryService.getSubCategories().subscribe((subcategory)=>{
      subcategory.forEach(value => this.subcategories.push(value));
    }); 
    console.log(this.subcategories);
    this.titlePage = "Add new product";
  }

  addProduct() {
    this.service.addProduct().subscribe((res: any) => 
    {
      alert("Product added succsefully.");
      this.router.navigateByUrl('/home');
    },
    err =>{
      this.toastr.error(err);
    });
  }

  onCategoryChanged(selectedCategoryId: any){
    this.selectedCategory = selectedCategoryId;
  }

  onSubCategoryChanged(selectedSubCategoryId: any){
    this.selectedSubCategory = selectedSubCategoryId;
  }

}
