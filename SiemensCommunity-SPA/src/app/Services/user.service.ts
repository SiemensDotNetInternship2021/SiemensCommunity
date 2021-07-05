import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup, AbstractControl, FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'http://localhost:52718/api';

  registrationModel = this.form.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Username : ['', Validators.required],
      Email : ['', [Validators.email, Validators.required]],
      Department : ['', Validators.required],
      OfficeFloor : ['', Validators.required],
      PhoneNumber : ['', Validators.required],
      Password : ['', Validators.required],
  });

  loginModel = this.form.group({
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', Validators.required],
  });

  constructor(private http: HttpClient, private form:FormBuilder) { }

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
}
