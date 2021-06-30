import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { User } from "../models/user";
import { UserService } from "../user.service";

@Injectable({ providedIn: 'root' })
export class UsersResolver implements Resolve<User[]> {
  constructor(private service: UserService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any>|Promise<any>|any {
    return this.service.getUsers();
  }
}