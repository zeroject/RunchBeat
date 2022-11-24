import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { PasswordStrengthMeterService } from 'angular-password-strength-meter';


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
  strength: any;


  constructor(private router: Router)
  {
  }

  ngOnInit(): void {
  }

  submit() {
    console.log(this.password)
    console.log(this.cpassword)
    console.log(this.strength)

  }

  cancel() {
    this.router.navigate(['./Login']);
  }
}
