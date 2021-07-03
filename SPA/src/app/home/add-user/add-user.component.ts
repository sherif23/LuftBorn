import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { FormsModule } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  user : User = {
      id : 0,
      phone : "" , 
      email : "",
      name : ""    
  };
  constructor(private userService : UserService) { }

  ngOnInit(): void {
  }

  onSubmit () {
    this.userService.addNewUser(this.user).subscribe (() => {

      alert ("Saved Successfully");
    }, error => {
      alert ("Error in saving user");
    });
  }
}
