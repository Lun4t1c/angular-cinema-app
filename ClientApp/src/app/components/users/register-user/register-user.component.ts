import { Component, OnInit } from '@angular/core';
import {UserModel} from "../../../models/UserModel";
import {AuthService} from "../../../services/auth.service";

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  userModel: Partial<UserModel> = {};

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  registerUser(){
    this.authService.registerUser(this.userModel as UserModel);
  }
}
