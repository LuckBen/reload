import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { RegistroRequest } from '../../models/request/registro.request';
import { Usuario } from '../../models/Usuario.model';
import {MatSnackBar} from '@angular/material/snack-bar';
import { CaptchaService } from '../../services/captcha.service';
import { Captcha } from '../../models/Captcha.model';
import { Router } from "@angular/router";

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  mail:string;
  nombre:string;
  password:string;
  cargando:boolean = false;
  regRequest:RegistroRequest;
  captchaValido:boolean;
  captcha:Captcha;
  constructor(private usService:UsuarioService,
              private captchaService:CaptchaService,
              private messageBox: MatSnackBar,
              private router: Router) { 
    this.regRequest = new RegistroRequest();
    
  }

  ngOnInit() {

    this.obtenerCaptcha();
  }
  
  obtenerCaptcha(){
    this.captchaService.getCaptcha().then(respCapcha=>{

      this.captcha = respCapcha.contenido;
      console.log(this.captcha);

    }).catch((err)=>{
      
      this.show('Ocurrió un error inesperado, inténtelo de nuevo','Aceptar');
    });
  }

  show(message: string, action: string) {
    this.messageBox.open(message, action, {
      duration: 3000,
    });
  }

  registrarse(){
      
      this.regRequest.usuario = this.nombre;
      this.regRequest.mail = this.mail;
      this.regRequest.password = this.password;
      
      if(!this.regRequest.usuario){
        this.show('Ingrese el nombre','Aceptar');
        return;
      }
            
      if(!this.regRequest.mail){
        this.show('Ingrese el mail','Aceptar');
        return;
      }

      if(!this.regRequest.password){
        this.show('Ingrese el password','Aceptar');
        return;
      }

      this.cargando = true;

      this.usService.registrarse(this.regRequest).then((data)=>{
        this.show(data.estado.mensaje,'Registro');
        this.router.navigate(['/posts'])

      })
      .catch((err)=>{
        
        this.show(err,'Aceptar');
      
      }).finally(()=>{
        this.cargando = false;
      });
  }
}
