import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-items',
  imports: [],
  templateUrl: './items.component.html',
  styleUrl: './items.component.css'
})

export class ItemsComponent implements OnInit {
  public listItems:Array<any> = [];
  private url:string = "https://localhost:7264/api/v1/item";

  ngOnInit(): void {
    this.buscarProdutos();
  }

  public async buscarProdutos():Promise<void> {
    try {
      const request = await fetch(this.url);
      const response = await request.json();

      this.listItems = response;
      console.log(this.listItems);

    } catch(error) {
      alert("Não foi possivel se comunicar com o servidor");
    }
    
  }
}
