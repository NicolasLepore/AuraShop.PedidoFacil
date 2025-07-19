import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginWrapperComponent } from "./components/login-wrapper/login-wrapper.component";

@Component({
  selector: 'app-root',
  imports: [RegisterComponent, LoginWrapperComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AuraShop.PedidoFacil.Web';
}
