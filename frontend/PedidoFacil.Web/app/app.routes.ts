import { Routes } from '@angular/router';
import { FormComponent } from './components/form/form.component';
import { SuccessComponent } from './components/success/success.component';
import { ItemsComponent } from './components/items/items.component';

export const routes: Routes = [
    {
        path: "",
        component: FormComponent 
    },
    {
        path: "success",
        component: SuccessComponent
    },
    {
        path: "items",
        component: ItemsComponent
    }
];
