import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { RegistroComponent } from './components/registro/registro.component';

const APP_ROUTES: Routes = [
    { path: 'posts', component: HomeComponent },
    { path:'registro', component:RegistroComponent},
    { path: '**', pathMatch: 'full', redirectTo: 'posts' }
  ];
  
  export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES, { useHash:true });