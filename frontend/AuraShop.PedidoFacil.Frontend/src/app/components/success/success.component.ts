import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-success',
  imports: [],
  templateUrl: './success.component.html',
  styleUrl: './success.component.css'
})

export class SuccessComponent {

  constructor(private route:Router) {

  }

  public navegar(url:string):void {
    this.route.navigate([url]);
  }
}
