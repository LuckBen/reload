import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { APP_ROUTING } from './app.routes';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClientModule,HttpClientJsonpModule, HTTP_INTERCEPTORS } from '@angular/common/http';

//services
  import { UsuarioService, CustomInterceptor } from './services/usuario.service';
// import { UsuarioService } from './services/usuario.service';


// angular material
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule} from '@angular/material/toolbar'; 
import { MatMenuModule} from '@angular/material/menu'; 
import { MatButtonModule} from '@angular/material/button'; 
import { MatButtonToggleModule} from '@angular/material/button-toggle'; 
import { MatIconModule} from '@angular/material/icon'; 
import { MatFormFieldModule} from '@angular/material/form-field'; 
import { MatInputModule} from '@angular/material/input'; 
import { MatProgressBarModule} from '@angular/material/progress-bar';
import { MatBadgeModule} from '@angular/material/badge';
import { BarraPerfilComponent } from './components/barra-perfil/barra-perfil.component';
import { BarraLogeoComponent } from './components/barra-logeo/barra-logeo.component';
import { RegistroComponent } from './components/registro/registro.component'; 
import { MatGridListModule} from '@angular/material/grid-list'; 
import { FormsModule } from '@angular/forms';
import { Usuario } from './models/Usuario.model';
import { MatSnackBarModule} from '@angular/material/snack-bar';
import { LoginComponent } from './components/login/login.component';
import { CheckLoginPipe } from './pipes/check-login.pipe';
import { MatDialogModule} from '@angular/material/dialog';
import { CuentaComponent } from './components/cuenta/cuenta.component';
import { MatTabsModule} from '@angular/material/tabs';
import { MatSelectModule} from '@angular/material/select';
import { CuentaDatosComponent } from './components/cuenta/cuenta-datos/cuenta-datos.component';
import { MatRadioModule} from '@angular/material/radio';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { CuentaPerfilComponent } from './components/cuenta/cuenta-perfil/cuenta-perfil.component';
import { CuentaCambiarClaveComponent } from './components/cuenta/cuenta-cambiar-clave/cuenta-cambiar-clave.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { UsuarioInfoComponent } from './components/perfil/usuario-info/usuario-info.component';
import { MatCardModule} from '@angular/material/card';
import { CabeceraPerfilComponent } from './components/perfil/cabecera-perfil/cabecera-perfil.component';
import { MatChipsModule} from '@angular/material/chips';
import { ImgPaisPipe } from './pipes/img-pais.pipe';
import { InfoComponent } from './components/perfil/info/info.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatSliderModule} from '@angular/material/slider'; 

/// editor
import { EditorComponent } from './components/editor/editor.component';
import { PerfilMiComponent } from './components/perfil/perfil-mi/perfil-mi.component';
import { PerfilPostsComponent } from './components/perfil/perfil-posts/perfil-posts.component';
import { PostsComponent } from './components/posts/posts.component';
import { PostComponent } from './components/post/post.component';
import { CategoriaPipe } from './pipes/categoria.pipe';
import { CrearPostComponent } from './components/post/crear-post/crear-post.component';
import { CargaArchivosComponent } from './components/carga-archivos/carga-archivos.component';
import { NgDropFilesDirective } from './directives/ng-drop-files.directive';
import { PostContenidoComponent } from './components/post/post-contenido/post-contenido.component';
import { InputComponent } from './components/otros/input/input.component';
import { ComentarioComponent } from './components/comentario/comentario.component';
import { ComentarioVisComponent } from './components/comentario-vis/comentario-vis.component';
import { PostVisualizaComponent } from './components/post/post-visualiza/post-visualiza.component';
import { InfoUsuarioComponent } from './components/info-usuario/info-usuario.component';
import { ImgRangoPipe } from './pipes/img-rango.pipe';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    BarraPerfilComponent,
    BarraLogeoComponent,
    RegistroComponent,
    LoginComponent,
    CheckLoginPipe,
    CuentaComponent,
    CuentaDatosComponent,
    CuentaPerfilComponent,
    CuentaCambiarClaveComponent,
    PerfilComponent,
    UsuarioInfoComponent,
    CabeceraPerfilComponent,
    ImgPaisPipe,
    InfoComponent,
    EditorComponent,
    PerfilMiComponent,
    PerfilPostsComponent,
    PostsComponent,
    PostComponent,
    CategoriaPipe,
    CrearPostComponent,
    CargaArchivosComponent,
    NgDropFilesDirective,
    PostContenidoComponent,
    InputComponent,
    ComentarioComponent,
    ComentarioVisComponent,
    PostVisualizaComponent,
    InfoUsuarioComponent,
    ImgRangoPipe
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
    MatProgressBarModule,
    MatSnackBarModule,
    HttpClientJsonpModule,
    MatDialogModule,
    MatTabsModule,
    MatSelectModule,
    MatRadioModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCardModule,
    MatChipsModule,
    MatProgressSpinnerModule,
    MatSliderModule
  ],
  providers: [
    UsuarioService,
    Usuario,
    // {provide: HTTP_INTERCEPTORS, useClass: CustomInterceptor, multi: true},
    MatDatepickerModule

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
