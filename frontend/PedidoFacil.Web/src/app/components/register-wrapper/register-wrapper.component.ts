import { Component } from '@angular/core';
import { FormRegisterComponent } from "./form-register/form-register.component";

@Component({
  selector: 'app-register-wrapper',
  imports: [FormRegisterComponent],
  templateUrl: './register-wrapper.component.html',
  styleUrl: './register-wrapper.component.css'
})

export class RegisterWrapperComponent {

}
