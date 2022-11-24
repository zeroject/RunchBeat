import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {MatSnackBar} from "@angular/material/snack-bar";
import * as EmailValidator from 'email-validator';



@Component({
  selector: 'app-new-user-page',
  templateUrl: './new-user-page.component.html',
  styleUrls: ['./new-user-page.component.css']
})
export class NewUserPageComponent implements OnInit {
  username: any;
  email: any;
  password: any;
  cpassword: any;
  strengthvalue: any;
  isEmailTrue: any;

  strength(event: any) {
    this.strengthvalue = event
  }


  constructor(private router: Router, private snackbar: MatSnackBar)
  {
  }

  ngOnInit(): void {

  }

  emailfailed(message: string, action:string){
    this.snackbar.open(message, action, {duration: 4000})
  }

  submit() {
    if(this.strengthvalue >= 2){
      if(this.password == this.cpassword){
        if(EmailValidator.validate(this.email)){
          this.snackbar.open("your credentials is good", "ok")
        }

        else {
          this.snackbar.open("Your email is not valid", "ok")
        }
      }
      else {
        this.snackbar.open("your passwords dont match", "ok")
      }
    }
    else {
      this.snackbar.open("your passwords is not strong enough", "ok")
    }

  }

  cancel() {
    this.router.navigate(['./Login']);
  }
}
