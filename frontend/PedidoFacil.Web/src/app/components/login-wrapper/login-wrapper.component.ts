import { Component } from '@angular/core';
import { FormLoginComponent } from "./form-login/form-login.component";
import { LoginHeaderComponent } from "./login-header/login-header.component";

@Component({
  selector: 'app-login-wrapper',
  imports: [FormLoginComponent, LoginHeaderComponent],
  templateUrl: './login-wrapper.component.html',
  styleUrl: './login-wrapper.component.css'
})
export class LoginWrapperComponent {

}
