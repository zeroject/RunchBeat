import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfilePageComponent } from './profile-page/profile-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { NewUserPageComponent } from './new-user-page/new-user-page.component';
import { BeatMakerPageComponent } from './beat-maker-page/beat-maker-page.component';
import {Routes} from "@angular/router";

const routes: Routes = [
  { path: 'ProfilePageComponent', component: ProfilePageComponent },
  { path: 'LoginPageComponent', component: LoginPageComponent },
  { path: 'NewUserPageComponent', component: NewUserPageComponent },
  { path: 'BeatMakerPageComponent', component: BeatMakerPageComponent}
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})

export class AppRoutingModule {

}
