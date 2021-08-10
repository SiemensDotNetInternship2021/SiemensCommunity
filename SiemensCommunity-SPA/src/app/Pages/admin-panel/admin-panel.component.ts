import { Component, OnInit } from '@angular/core';
import { FilterPipe } from 'ngx-filter-pipe';
import { IUser } from 'src/app/Models/IUserDTO';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  userFilter: any = {lastName: ''};
  users: IUser[] = []
  constructor(public service: UserService, private filterPipe:FilterPipe) { 
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.service.getUsers().subscribe(usersFromDB => {
      this.users = usersFromDB;
    })
  }

}
