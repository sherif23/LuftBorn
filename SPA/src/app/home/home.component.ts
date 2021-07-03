import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from '../models/user';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  users : User [];
  constructor( private route : ActivatedRoute ,private userService : UserService) {

   }

  ngOnInit(): void {


    this.route.data.subscribe (data => {
      this.users = data ['users'];
    })

  }

  onDelete ( index : number) {
    this.userService.deleteUser(this.users[index].id).subscribe (() => {
      this.users.splice(index,1);
      alert ("Deleted Successfully");
      
    }, error => {
      alert ("Error in deleting user");
    });
  }

}
