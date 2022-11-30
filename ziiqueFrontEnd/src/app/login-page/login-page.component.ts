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
  username_Email: any;


  constructor(private http: HttpService) { }

  ngOnInit(): void {
  }

   Submit() {
    let dto = {
      username_Email: this.username_Email,
      password: this.password
    }
    this.http.login(dto);
  }
}
