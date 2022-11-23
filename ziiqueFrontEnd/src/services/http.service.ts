import { Injectable } from '@angular/core';
import axios from "axios";
import * as https from "https";

export const customAxios = axios.create(
  {
    baseURL: 'https:/localhost:7003',
    headers: {
      Authorization: `bearer ${localStorage.getItem('token')}`
    }
  }
)

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

async login(dto: any)
{
  const httpResponse = await customAxios.post('auth/login', dto)
  return httpResponse.data;
}
}
