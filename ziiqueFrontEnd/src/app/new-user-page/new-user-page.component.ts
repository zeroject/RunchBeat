import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

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

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  submit() {

  }

  cancel() {
    this.router.navigate(['./Login']);
  }
}
