import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  password: any;
  username: any;

  constructor() { }

  ngOnInit(): void {
  }

  Submit() {

  }
}
