import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  user : User 
  constructor(private route : ActivatedRoute , private userService : UserService) { }

  ngOnInit(): void {

    this.route.data.subscribe (data => {
      this.user = data ['user'];
    })
  }

  onSubmit () {
    this.userService.updateUser(this.user).subscribe (() => {

      alert ("Updated Successfully");
    }, error => {
      alert ("Error in updating user");
    });
  }
}
