import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginWrapperComponent } from "./components/login-wrapper/login-wrapper.component";
import { RegisterWrapperComponent } from "./components/register-wrapper/register-wrapper.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AuraShop.PedidoFacil.Web';
}
