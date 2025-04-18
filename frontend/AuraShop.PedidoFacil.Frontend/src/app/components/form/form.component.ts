import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form',
  imports: [],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})

export class FormComponent {

  private url:string = "https://localhost:7264/api/v1/item";

  constructor(private router: Router) {}
  
  public async cadastrar(event:any):Promise<void> {
    event.preventDefault();

    const data:Object = {
      "nome": event.target.nome.value,
      "tamanho": event.target.tamanho.value,
      "cor": event.target.cor.value,
      "preco": event.target.preco.value
    };
    
    try {
      const request = await fetch(this.url, {
        method: "POST",
        headers: {
          "Content-Type": "Application/json"
        },
        body: JSON.stringify(data)
      });
  
      const response = await request.json();
      this.router.navigate(['/success']);

    } catch(error) {
      alert("Erro ao cadastrar produto");
    }
    
  }
}
