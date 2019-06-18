import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  public logeado:boolean;

  constructor(private router:Router ) {}

  ngOnInit() {
    this.logeado = UsuarioService.logeado;
  }

  estaLogeado():boolean{
    return UsuarioService.logeado;
  }
}
