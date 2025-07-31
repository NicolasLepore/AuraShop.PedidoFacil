import { Routes } from '@angular/router';
import { LoginWrapperComponent } from './components/login-wrapper/login-wrapper.component';
import { RegisterWrapperComponent } from './components/register-wrapper/register-wrapper.component';

export const routes: Routes = [
    {
        path: "",
        component: RegisterWrapperComponent
    },
    {
        path: "login",
        component: LoginWrapperComponent
    }
];
