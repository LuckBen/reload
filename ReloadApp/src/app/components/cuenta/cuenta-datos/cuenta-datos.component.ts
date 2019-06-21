import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../../models/Usuario.model';
import { UsuarioService } from '../../../services/usuario.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import { Pais } from '../../../models/Pais.model';
import { HelperService } from '../../../services/helper.service';

@Component({
  selector: 'app-cuenta-datos',
  templateUrl: './cuenta-datos.component.html',
  styleUrls: ['./cuenta-datos.component.css']
})
export class CuentaDatosComponent implements OnInit {
   
  usuario:Usuario;
  cargando:boolean = false;
  paises:Pais[] = [];
  fechaCumple:Date;  
  constructor(private   ucService:UsuarioService,
              private messageBox: MatSnackBar,
              private helper:HelperService
    ) { 
    this.usuario = UsuarioService.usuario;
    this.fechaCumple = new Date(this.usuario.info.fechaNac);
    helper.getPaises().then(data=>{
      this.paises = data.contenido;
    });
  }

  ngOnInit() {
  
  }

  cambiarInfo(){
    
      
    this.usuario.info.fechaNac = this.fechaCumple.toLocaleDateString();

    this.cargando = true;
    this.ucService.saveInfo(this.usuario).then(data=>{
      UsuarioService.usuario = data.contenido;
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
