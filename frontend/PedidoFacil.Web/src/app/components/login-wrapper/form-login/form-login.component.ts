import { Component } from '@angular/core';

@Component({
  selector: 'app-form-login',
  imports: [],
  templateUrl: './form-login.component.html',
  styleUrl: './form-login.component.css'
})

export class FormLoginComponent {

  public visible:boolean = false;

  public showPassword(event:any):void {
    this.visible = !this.visible;
  }
}
