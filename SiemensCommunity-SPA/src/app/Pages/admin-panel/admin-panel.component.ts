import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FilterPipe } from 'ngx-filter-pipe';
import { IUser } from 'src/app/Models/IUserDTO';
import { UserService } from 'src/app/Services/user.service';
import { UserEditorComponent } from '../user-editor/user-editor.component';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  userFilter: any = {lastName: ''};
  users: IUser[] = [];
  currentDialog: any = null;
  constructor(public service: UserService, private filterPipe:FilterPipe,
    public modalService: NgbModal) { 
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.service.getUsers().subscribe(usersFromDB => {
      this.users = usersFromDB;
    })
  }

  openUserEditor(userId : number)
  {
      this.currentDialog = this.modalService.open(UserEditorComponent);
      this.currentDialog.componentInstance.userId = userId;
  }

}
