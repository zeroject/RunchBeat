import { Component, OnInit } from '@angular/core';
import {Routes, RouterModule} from "@angular/router";
import { HttpService } from "../../services/http.service";
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  password: any;
  username: any;


  constructor(private http: HttpService, private snackbar: MatSnackBar) { }

  ngOnInit(): void {
  }

  async Submit() {
    if (!this.username) {
      this.snackbar.open("Remember to enter either your email or username", "Ok")
      
    }
    else if (!this.password) {
      this.snackbar.open("Remember to enter your password", "Ok")
    }
    let dto = {
      username: this.username,
      password: this.password

    }
    var token = await this.http.login(dto)
    // @ts-ignore
    localStorage.setItem('token', token)
  }
}
