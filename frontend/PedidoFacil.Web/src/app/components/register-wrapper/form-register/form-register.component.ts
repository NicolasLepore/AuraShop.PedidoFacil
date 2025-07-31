import { Component } from '@angular/core';

@Component({
  selector: 'app-form-register',
  imports: [],
  templateUrl: './form-register.component.html',
  styleUrl: './form-register.component.css'
})

export class FormRegisterComponent {
  public isPassVisible:boolean = false;
  public isRePassVisible:boolean = false;

  public viewPassword() {
    this.isPassVisible = !this.isPassVisible;
  } 

  public viewRePassword() {
    this.isRePassVisible = !this.isRePassVisible;
  }
}
