import { Component } from '@angular/core';
import { UsuarioService } from './services/usuario.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
  public htmlcontent:string;
  title = 'ReloadApp';

  constructor(private usService:UsuarioService){
    this.usService.cargar();
  }
}
