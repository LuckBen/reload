import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  public logeado:boolean;

  constructor() {

    this.logeado = UsuarioService.logeado;
   }

  ngOnInit() {
  }

}
