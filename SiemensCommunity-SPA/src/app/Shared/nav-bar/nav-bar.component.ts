import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  checkifAdmin : boolean = false;
  constructor(public router: Router, public service: UserService) { }

  ngOnInit(): void {
    this.checkifAdmin = this.service.getAndCheckUserRole();
    console.log(this.checkifAdmin);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login'])
  }
}
