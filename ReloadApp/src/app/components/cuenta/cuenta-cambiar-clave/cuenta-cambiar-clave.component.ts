import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../../models/Usuario.model';
import { UsuarioService } from '../../../services/usuario.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import { Pais } from '../../../models/Pais.model';
import { HelperService } from '../../../services/helper.service';

@Component({
  selector: 'app-cuenta-cambiar-clave',
  templateUrl: './cuenta-cambiar-clave.component.html',
  styleUrls: ['./cuenta-cambiar-clave.component.css']
})
export class CuentaCambiarClaveComponent implements OnInit {

  usuario:Usuario;
  cargando:boolean = false;
  passwordOriginal:string;
  passwordNuevo:string;

  constructor(private   ucService:UsuarioService,
              private messageBox: MatSnackBar,
              private helper:HelperService
    ) { 
    this.usuario = UsuarioService.usuario;
  }

  ngOnInit() {
  
  }

  cambiarClave(){

    this.cargando = true;
    if(!this.passwordOriginal){
      this.show("Ingrese la clave actual","Aceptar");
      return;
    }

    if(!this.passwordNuevo){
      this.show("Ingrese la nueva clave","Aceptar");
      return;
    }

    this.ucService.cambiarClave(this.passwordOriginal,this.passwordNuevo).then(data=>{
      this.show('Datos actualizados correctamente!','Aceptar');
    })
    .catch((err)=>{
      this.show(err,'Aceptar');
    })
    .finally(()=>{
      this.cargando = false;
    });

  }
  
  show(message: string, action: string) {
    this.messageBox.open(message, action, {
      duration: 2000,
    });
  }
}
