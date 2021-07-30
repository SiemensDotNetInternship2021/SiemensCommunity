import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  
 
  constructor(public service: UserService,
    private router: Router,
    private toastr: ToastrService ) { }

  ngOnInit(): void {
  }

  login() {
    this.service.login().subscribe((res: any) => 
    {
      localStorage.setItem('token', res.token);
      this.router.navigateByUrl('/home');
    },
    err=>{
      this.toastr.error("Invalid credentials");
    });
  }
}
