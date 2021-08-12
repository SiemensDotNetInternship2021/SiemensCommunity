import { Component, Input, OnInit } from '@angular/core';
import { resetFakeAsyncZone } from '@angular/core/testing';
import { FormBuilder, NgForm, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { IDepartment } from 'src/app/Models/IDepartment';
import { IUserDTO } from 'src/app/Models/IUserDTO';
import { DepartmentService } from 'src/app/Services/department-service/department.service';
import { UserService } from 'src/app/Services/user.service';
import { ChangeValueValidator } from 'src/app/Shared/CustomValidators/changedvalue.validator';

@Component({
  selector: 'app-user-editor',
  templateUrl: './user-editor.component.html',
  styleUrls: ['./user-editor.component.css']
})

export class UserEditorComponent implements OnInit {


  user !: IUserDTO 
  departments: IDepartment[] =[]
  @Input() userId: number = 0;
  roles : string[] =[]
  userRoles : string[] =[]
  editUserModel = this.form.group({
    Id: ['', Validators.required],
    FirstName: ['', Validators.required],
    LastName: ['', Validators.required],
    UserName : ['', Validators.required],
    Department : ['', Validators.required],
    OfficeFloor : ['', Validators.required],
  })

  constructor(public modalService: NgbModal, public activeModal: NgbActiveModal,
    public userService: UserService, public departmentService: DepartmentService, 
    private form:FormBuilder, public toastr: ToastrService) { 
    }

  ngOnInit(): void {
    this.getUserById(this.userId);
    this.getDepartments();
    this.getRoles();
  }

  getUserById(userId : number) {
    this.userService.getUserById(userId).subscribe((userFromDB) => {
        this.user = userFromDB

        this.editUserModel = this.form.group({
          Id: [this.user.id, Validators.required],
          FirstName: [this.user.firstName, Validators.required],
          LastName: [this.user.lastName, Validators.required],
          UserName : [this.user.userName, Validators.required],
          Department : [this.user.department, Validators.required],
          OfficeFloor : [this.user.officeFloor, Validators.required],
        })
    })
  }

  getDepartments()
  {
      this.departmentService.getDepartments().subscribe((department) => {
        department.forEach(value => this.departments.push(value));
      })
  }

  getRoles()
  {
    this.userService.getRoles().subscribe((res : any) => {
      this.roles = res;
    })
  }

  submitChanges()
  {
    this.userService.sendUpdatedUser(this.editUserModel, this.userRoles).subscribe((res: any) => 
    {
      this.toastr.success("User details have been updated!");
    },
    err=>{
      this.toastr.error("Oh no :( something went wrong");
    });
  }

  updateUserRole(event : any) 
  {
    this.userRoles = this.user.roles;
    this.userRoles.push(event.target.value);
    console.log(this.userRoles);
  }

  removeUserRole(event : any)
  {
    this.userRoles =this.user.roles;
    const roleIndex = this.userRoles.indexOf(event.target.value);
    if( roleIndex !== -1) {
      this.userRoles.splice(roleIndex, 1);
    }
    console.log(this.userRoles);
  }
}
