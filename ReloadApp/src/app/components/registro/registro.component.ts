import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { RegistroRequest } from '../../models/request/registro.request';
import { Usuario } from '../../models/Usuario.model';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  mail:string;
  nombre:string;
  password:string;

  regRequest:RegistroRequest;

  constructor(private usService:UsuarioService) { 
    this.regRequest = new RegistroRequest();
    
  }

  ngOnInit() {
  }
  
  registrarse(){
      
      this.regRequest.usuario = this.nombre;
      this.regRequest.mail = this.mail;
      this.regRequest.password = this.password;
  
      this.usService.registrarse(this.regRequest);
  }
}
