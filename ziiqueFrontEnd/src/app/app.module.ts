import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { NewUserPageComponent } from './new-user-page/new-user-page.component';
import { BeatMakerPageComponent } from './beat-maker-page/beat-maker-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {FormsModule} from "@angular/forms";
import {MatExpansionModule} from "@angular/material/expansion";
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {RouterModule, RouterOutlet, Routes} from "@angular/router";
import {AuthguardService} from "../services/authguard.service";
import { PasswordStrengthMeterModule } from 'angular-password-strength-meter';
import {MatSnackBarModule} from '@angular/material/snack-bar'


const routes: Routes = [
  { path: 'profile', component: ProfilePageComponent, canActivate: [AuthguardService]},
  { path: 'login', component: LoginPageComponent },
  { path: 'newuser', component: NewUserPageComponent },
  { path: 'beatmaker', component: BeatMakerPageComponent, canActivate: [AuthguardService]},
  { path: '**', redirectTo:'login'}
];

@NgModule({
  declarations: [
    AppComponent,
    ProfilePageComponent,
    LoginPageComponent,
    NewUserPageComponent,
    BeatMakerPageComponent
  ],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatExpansionModule,
    MatButtonModule,
    RouterOutlet,
    MatCardModule,
    PasswordStrengthMeterModule.forRoot(),
    MatSnackBarModule
  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
