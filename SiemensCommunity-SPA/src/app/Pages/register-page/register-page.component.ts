import { Component, OnInit } from '@angular/core';
import { NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {

  constructor(public service: UserService,
    public router: Router) { }
  ngOnInit(): void {
  }

  register() {
    this.service.register().subscribe((res: any) => 
    {
      this.router.navigateByUrl('/home');
    })
  }

}
