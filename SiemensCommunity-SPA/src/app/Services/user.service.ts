import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup, AbstractControl, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IUserDTO } from '../Models/IUserDTO';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'http://localhost:52718/api';
  email: string = "";
  token: string = "";
  userRole: string ="";
  test: string = "Admin";

  registrationModel = this.form.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Username : ['', Validators.required],
      Email : ['', [Validators.email, Validators.required]],
      Department : ['', Validators.required],
      OfficeFloor : ['', Validators.required],
      PhoneNumber : ['', Validators.required],
      Password : ['', [Validators.required, Validators.minLength(6), Validators.pattern(".*[0-9].*")]],
      ConfirmPassword : ['', Validators.required]
  });

  loginModel = this.form.group({
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', Validators.required]
  });

  forgotPasswordModel = this.form.group({
    Email: ['', [Validators.required, Validators.email]]
  });

  resetPasswordModel = this.form.group({
    Password: ['', [Validators.required, Validators.minLength(6), Validators.pattern(".*[0-9].*")]],
    ConfirmPassword: ['', Validators.required],
  });

  constructor(private http: HttpClient, private form:FormBuilder, private route: ActivatedRoute) {
   }

  register() {
    var registerData = {
      Username : this.registrationModel.value.Username,
      Email : this.registrationModel.value.Email,
      FirstName : this.registrationModel.value.FirstName,
      LastName : this.registrationModel.value.LastName,
      Department : this.registrationModel.value.Department,
      OfficeFloor : this.registrationModel.value.OfficeFloor,
      PhoneNumber : this.registrationModel.value.PhoneNumber,
      Password: this.registrationModel.value.Password,
     // ConfirmPassword: this.registrationModel.value.ConfirmPassword,
    }
    return this.http.post(this.rootUrl + '/Account/register', registerData);
  }

  login () {
    var loginData = {
      Email: this.loginModel.value.Email,
      Password: this.loginModel.value.Password,
    }
    return this.http.post(this.rootUrl + '/Account/login', loginData);
  }

  recoverPassword(){
    var recoverData = {
      Email: this.forgotPasswordModel.value.Email
    }
    return this.http.get(this.rootUrl + '/Account/forgotPassword?email='+ recoverData.Email);
  }

  resetPassword(){
    var resetPassworData = {
      Password: this.resetPasswordModel.value.Password,
      Email: this.route.snapshot.queryParamMap.get('email'),
      Token: this.route.snapshot.queryParamMap.get('token'),
    }
    console.log(resetPassworData.Email);
    return this.http.post(this.rootUrl + '/Account/resetpassword', resetPassworData);
  }

  getAndCheckUserRole() {
    var token = localStorage.getItem('token');
    var tokenDetails : any;
    if(token != null) {
      tokenDetails = window.atob(token.split('.')[1]);
    }
    tokenDetails = JSON.parse(tokenDetails);
    console.log(tokenDetails)
    this.userRole = tokenDetails.role;
    console.log("asta e roleu " + " " + this.userRole);
    if(this.userRole === "Admin")
    {
      return true;
    }
    else 
    {
      return false;
    }
  }

  roleMatch(allowedRoles : string[]) : boolean{
    var isMatch = false;
    allowedRoles.forEach(allowedRole => {
      if(this.userRole == allowedRole)
      {
        console.log("User role din alta functie " + this.userRole);
        return isMatch = true;
      }
      else 
      {
        return isMatch = false;
      }
    });
    return isMatch;
  }

  getUsers() {
    return this.http.get<IUserDTO[]>(this.rootUrl + '/User/');
  }

  getUserById(userId: number) {
    return this.http.get<IUserDTO>(this.rootUrl + '/User/getUser?userId='+ userId);
  }

  getRoles(){
    return this.http.get(this.rootUrl + '/User/getRoles');
  }

  sendUpdatedUser(editUserModel : any, userRoles : string[]) {
    var userDetails = {
      id : editUserModel.value.Id,
      lastName : editUserModel.value.LastName,
      firstName: editUserModel.value.FirstName,
      userName : editUserModel.value.UserName,
      department : editUserModel.value.Department,
      officeFloor : editUserModel.value.OfficeFloor,
      roles : userRoles,
    }
    console.log(userDetails.roles);
    return this.http.post(this.rootUrl + '/User/updateUser', userDetails);
  }
}
