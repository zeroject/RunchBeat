import { Component, OnInit } from '@angular/core';
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
  x: any;
  y: any;
  z: any;



  constructor(private http: HttpService, private snackbar: MatSnackBar) {

  }

  ngOnInit(): void {
  }

  async Submit() {
    console.log(this.username)
    console.log(this.password)
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
    console.log(dto)
    var token = await this.http.login(dto)
    // @ts-ignore
    localStorage.setItem('token', token)
  }
  SwitchLogin(){
    console.log('ijliji')
    var x = document.getElementById("login");
    var y = document.getElementById("register");
    var z = document.getElementById("btn");
    var b = document.getElementById("btn-login");
    var bt = document.getElementById("btn-register");
    // @ts-ignore
    x.style.left = "50px";
    // @ts-ignore
    y.style.left = "450px";
    // @ts-ignore
    z.style.left = "0";
    // @ts-ignore
    b.style.color = "white";
    // @ts-ignore
    bt.style.color = "black";
  }

  SwitchRegister(){
    console.log('jhgfdhy')
    var x = document.getElementById("login");
    var y = document.getElementById("register");
    var z = document.getElementById("btn");
    var b = document.getElementById("btn-login");
    var bt = document.getElementById("btn-register");
    // @ts-ignore
    x.style.left = "-400px";
    // @ts-ignore
    y.style.left = "50px";
    // @ts-ignore
    z.style.left = "110px";
    // @ts-ignore
    b.style.color = "black";
    // @ts-ignore
    bt.style.color = "white";
  }
}
