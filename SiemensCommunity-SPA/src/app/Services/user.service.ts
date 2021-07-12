import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup, AbstractControl, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'http://localhost:52718/api';
  email: string = "";
  token: string= "";

  registrationModel = this.form.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Username : ['', Validators.required],
      Email : ['', [Validators.email, Validators.required]],
      Department : ['', Validators.required],
      OfficeFloor : ['', Validators.required],
      PhoneNumber : ['', Validators.required],
      Password : ['', Validators.required],
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
    Password: ['', Validators.required],
    ConfirmPassword: ['', Validators.required],
  })

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
}
