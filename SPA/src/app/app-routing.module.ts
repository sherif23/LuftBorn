import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUserComponent } from './home/add-user/add-user.component';
import { EditUserComponent } from './home/edit-user/edit-user.component';
import { HomeComponent } from './home/home.component';
import { UserResolver } from './resolvers/user.resolver';
import { UsersResolver } from './resolvers/users.resolver';


const routes: Routes = [
  { path: '', component: HomeComponent , resolve : {users : UsersResolver}},
  { path: 'add', component: AddUserComponent },
  { path: 'edit/:id', component: EditUserComponent , resolve : {user : UserResolver} }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }