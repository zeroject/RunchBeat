import { Component, OnInit } from '@angular/core';
import {Routes, RouterModule} from "@angular/router";
import {HttpService} from "../../services/http.service";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  password: any;
  username: any;


  constructor(private http: HttpService) { }

  ngOnInit(): void {
  }

  async Submit() {
    let dto = {
      username: this.username,
      password: this.password

    }
    var token = await this.http.login(dto)
    localStorage.setItem('token', token)
  }
}
