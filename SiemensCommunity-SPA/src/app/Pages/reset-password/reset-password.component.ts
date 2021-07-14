import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  constructor(public service: UserService,
    public router: Router,
    public route: ActivatedRoute,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    console.log(this.route.snapshot.queryParamMap.get('email'));
    console.log(this.route.snapshot.queryParamMap.get('token'));
  }

  resetPassword(){
    this.service.resetPassword().subscribe((res: any)=>{
      this.router.navigateByUrl('/home');
    },
    err=>{
      this.toastr.error('Invalid request');
    });
  }
}
