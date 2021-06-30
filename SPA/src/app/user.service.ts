import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { User } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

 

 baseUrl = environment.baseUrl;

 constructor(private http: HttpClient) { }


  getUsers () {
    return this.http.get<User []>(this.baseUrl);
  }

  addNewUser (user : User) {
    
    return this.http.post<User>(this.baseUrl + "/addnewuser", user);
  }

  getUser (id : number) {
    return this.http.get<User>(this.baseUrl+"/"+id);
  }

  updateUser (user : User) {
    return this.http.put<User>(this.baseUrl + "/updateuser", user);
  }

  deleteUser (id : number) {
    return this.http.delete(this.baseUrl+"/"+id);
  }
  
}
