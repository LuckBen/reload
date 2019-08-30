import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../../models/Usuario.model';
import { UsuarioService } from '../../../services/usuario.service';
import { MatSnackBar} from '@angular/material/snack-bar';
import { Pais } from '../../../models/Pais.model';
import { HelperService } from '../../../services/helper.service';
import { Data } from '@angular/router';

@Component({
  selector: 'app-cuenta-perfil',
  templateUrl: './cuenta-perfil.component.html',
  styleUrls: ['./cuenta-perfil.component.css'],
})
export class CuentaPerfilComponent implements OnInit {
  usuario:Usuario;
  cargando:boolean = false;
  paises:Pais[] = [];
  
  constructor(private   ucService:UsuarioService,
              private messageBox: MatSnackBar,
              private helper:HelperService,
    )  { 
      this.usuario = new Usuario();
      this.usuario = UsuarioService.usuario;
      let fecha:string = new Date().toLocaleDateString();
      console.log(fecha);

  }

  ngOnInit() {
  }


  cambiarInfo(){
    
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
