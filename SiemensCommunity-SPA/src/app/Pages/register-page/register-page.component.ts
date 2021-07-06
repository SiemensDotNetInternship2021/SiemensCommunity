import { Component, OnInit } from '@angular/core';
import { NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { pipe } from 'rxjs';
import { IDepartment } from 'src/app/Models/IDepartment';
import { DepartmentService } from 'src/app/Services/department-service/department.service';
import { UserService } from 'src/app/Services/user.service';


@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {

  departments : IDepartment[] = [];

  constructor(public service: UserService,
    public serviceDepartment: DepartmentService,
    public router: Router) { 
      this.departments = [];
    }
    

    ngOnInit(): void {
      this.getDepartments();
    }

  register() {
    this.service.register().subscribe((res: any) => 
    {
      this.router.navigateByUrl('/home');
    })
  }

  getDepartments() {
    this.serviceDepartment.getDepartments().subscribe((department) => {
      department.forEach(value => this.departments.push(value));
    })
  }

}
