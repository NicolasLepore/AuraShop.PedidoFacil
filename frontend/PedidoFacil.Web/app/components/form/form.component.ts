import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form',
  imports: [],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})

export class FormComponent {

  constructor(private router: Router) {}
  
  public cadastrar(event:Event):void {
    event.preventDefault();
    this.router.navigate(['/success']);
  }
}
