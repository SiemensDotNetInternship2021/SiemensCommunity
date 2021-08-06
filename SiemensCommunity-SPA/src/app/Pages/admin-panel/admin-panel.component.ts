import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/Models/IUserDTO';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {


  users: IUser[] = []
  constructor(public service: UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.service.getUsers().subscribe(usersFromDB => {
      this.users = usersFromDB;
    })
  }

}
