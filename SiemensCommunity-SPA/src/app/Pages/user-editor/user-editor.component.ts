import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IUser } from 'src/app/Models/IUserDTO';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-user-editor',
  templateUrl: './user-editor.component.html',
  styleUrls: ['./user-editor.component.css']
})
export class UserEditorComponent implements OnInit {

  user: any;

  @Input() userId: number = 0;
  constructor(public modalService: NgbModal, public activeModal: NgbActiveModal,
    public userService: UserService,) { 
    
    }

  ngOnInit(): void {
    this.getUserById(this.userId)
  }

  getUserById(userId : number) {
    this.userService.getUserById(userId).subscribe(res => {
        this.user = res;
    })
  }

}
