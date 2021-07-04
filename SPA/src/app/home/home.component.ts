import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../models/user';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  token:{id:string, name:string , email:string , photoUrl:string ,firstName : string , lastName : string
  , authToken:string , idToken : string , response : string , provider : string}
  users : User [];
  name : string;
  constructor( private route : ActivatedRoute ,private userService : UserService ,private  router : Router) {

   }

  ngOnInit(): void {


    this.route.data.subscribe (data => {
      this.users = data ['users'];
    })

    this.token = JSON.parse( localStorage.getItem ("google_auth"));
  
  }

  onDelete ( index : number) {
    this.userService.deleteUser(this.users[index].id).subscribe (() => {
      this.users.splice(index,1);
      alert ("Deleted Successfully");
      
    }, error => {
      alert ("Error in deleting user");
    });
  }

  onLogout () {

    localStorage.removeItem('google_auth');
    this.router.navigate(['']);
  }

}
