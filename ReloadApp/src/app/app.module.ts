import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { APP_ROUTING } from './app.routes';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClientModule,HttpClientJsonpModule, HTTP_INTERCEPTORS } from '@angular/common/http';

//services
import { UsuarioService, CustomInterceptor } from './services/usuario.service';


// angular material
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar'; 
import {MatMenuModule} from '@angular/material/menu'; 
import {MatButtonModule} from '@angular/material/button'; 
import {MatButtonToggleModule} from '@angular/material/button-toggle'; 
import {MatIconModule} from '@angular/material/icon'; 
import {MatFormFieldModule} from '@angular/material/form-field'; 
import {MatInputModule} from '@angular/material/input'; 

import {MatBadgeModule} from '@angular/material/badge';
import { BarraPerfilComponent } from './components/barra-perfil/barra-perfil.component';
import { BarraLogeoComponent } from './components/barra-logeo/barra-logeo.component';
import { RegistroComponent } from './components/registro/registro.component'; 
import {MatGridListModule} from '@angular/material/grid-list'; 
import { FormsModule } from '@angular/forms';
import { Usuario } from './models/Usuario.model';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    BarraPerfilComponent,
    BarraLogeoComponent,
    RegistroComponent
  ],
  imports: [
    BrowserModule,
    APP_ROUTING,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatIconModule,
    MatBadgeModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatGridListModule,
    FormsModule,
    HttpClientJsonpModule
  ],
  providers: [UsuarioService,Usuario,
     {provide: HTTP_INTERCEPTORS, useClass: CustomInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
