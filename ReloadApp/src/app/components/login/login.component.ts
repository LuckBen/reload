import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { LoginRequest } from '../../models/request/login.request';
import { Usuario } from '../../models/Usuario.model';
import {MatSnackBar} from '@angular/material/snack-bar';
import { CaptchaService } from '../../services/captcha.service';
import { Captcha } from '../../models/Captcha.model';
import { Router } from "@angular/router";
import { NavbarComponent } from '../navbar/navbar.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  mail:string;
  nombre:string;
  password:string;
  cargando:boolean = false;
  logRequest:LoginRequest;
  captchaValido:boolean;
  captcha:Captcha;

  constructor(private usService:UsuarioService,
              private captchaService:CaptchaService,
              private messageBox: MatSnackBar,
              private router: Router) { 
    this.logRequest = new LoginRequest();
    
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
      duration: 10000,
    });
  }

  
  logearse(){
      
    this.logRequest.login = this.nombre;
    this.logRequest.password = this.password;
    
    if(!this.logRequest.login){
      this.show('Ingrese el nombre','Aceptar');
      return;
    }

    if(!this.logRequest.password){
      this.show('Ingrese el password','Aceptar');
      return;
    }

    this.cargando = true;

    this.usService.logearse(this.logRequest).then((data)=>{
      this.router.navigate(['/posts'])

    })
    .catch((err)=>{
      
      this.show(err,'Aceptar');
    
    }).finally(()=>{
      this.cargando = false;
    });
}
}