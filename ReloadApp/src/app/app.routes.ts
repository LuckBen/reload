import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { RegistroComponent } from './components/registro/registro.component';
import { LoginComponent } from './components/login/login.component';
import { CuentaComponent } from './components/cuenta/cuenta.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { CrearPostComponent } from './components/post/crear-post/crear-post.component';

const APP_ROUTES: Routes = [
    { path:'posts', component:HomeComponent },
    { path:'registro', component:RegistroComponent},
    { path:'login' , component:LoginComponent},
    { path:'cuenta', component:CuentaComponent},
    { path:'perfil/:codigo', component: PerfilComponent},
    { path:'crear/post',component:CrearPostComponent},
    { path: '**', pathMatch: 'full', redirectTo: 'posts' }
  ];
  
  export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES, { useHash:true });