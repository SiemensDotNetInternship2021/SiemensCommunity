import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  constructor(public service: UserService,
    public router: Router) { 
  }

  ngOnInit(): void {
  }

  recoverPassword() {
    this.service.recoverPassword().subscribe((res : any) => {
      this.router.navigateByUrl('/login');
    })
  }
}