import { Component, OnInit } from '@angular/core';
import {DataAccessService} from "../../services/data-access.service";
import {EmailValidator} from "@angular/forms";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";
import {NotExpr} from "@angular/compiler";
import {Observable} from "rxjs";
import {UserModel} from "../../models/UserModel";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  email: string = '';
  password: string = '';
  isLoginFailed: boolean = false;
  loggedUser!: Observable<UserModel | null>;

  constructor(
    private auth: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loggedUser = this.auth.getLoggedUserObservable();
  }

  submit() {
    this.auth.authenticateUser(this.email, this.password)
      .subscribe(next => {
        if (next === true)
          this.loginSucceeded();
        else
          this.loginFailed();
      });
  }

  register(): void{
    this.router.navigate(['register']);
  }

  private loginFailed(): void{
      console.log("Login failed");
      this.isLoginFailed = true;
  }

  private loginSucceeded(){
    console.log("Login ok");
    this.router.navigate(['']);
  }
}
