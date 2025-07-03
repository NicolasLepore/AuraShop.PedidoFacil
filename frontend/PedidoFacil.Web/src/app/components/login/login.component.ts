import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {

  public visible:boolean = false;

  public showPassword(event:any):void {
    this.visible = !this.visible;
  }
}
