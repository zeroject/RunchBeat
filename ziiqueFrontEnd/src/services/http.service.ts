import { Injectable } from '@angular/core';
import axios from "axios";
import * as https from "https";
import jwtDecode from "jwt-decode";
import { User } from "../User";
import {environment} from "../environments/environment";
import {Router} from "@angular/router";


export const customAxios = axios.create(
  {
    baseURL: 'https:/localhost:7003/api',
    headers: {
      Authorization: `bearer ${localStorage.getItem('token')}`
    }
  }
)

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  username: any;
  email: any;
  twoFA: any;


  constructor(private router: Router) {

  }

async login(dto: any)
{
  customAxios.post('auth/login', dto).then(successResult =>{
    localStorage.setItem('token', successResult.data);
    let t = jwtDecode(successResult.data)as User;
    this.username = t.username;
    this.email = t.email;
    this.twoFA = t.twoFA;
    this.router.navigate(['./BeatMaker'])
  })


}

async createUser(Dto: {username: any, password: any, email: any, is2FA: any}){
    const httpResult = await customAxios.post("User/createUser", Dto)
  console.log(httpResult)
    return httpResult.status.toString()
}

}
