import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpInterceptor, HttpHandler, HttpEvent, HttpRequest } from  '@angular/common/http';
import { Usuario } from '../models/Usuario.model';
import { RegistroRequest } from '../models/request/registro.request';
import { URL_AUTHENTICATION_SERVICE, URL_USER_SERVICE, URL_POST_SERVICE } from './urlservicios.url';
import { Response } from '../models/response/response.response';
import { Observable } from 'rxjs';
import { LoginRequest } from '../models/request/login.request';
import { Request } from '../models/request/Request.request';
import { UsuarioInfo } from '../models/UsuarioInfo.model';
import { UsuarioInfoRequest } from '../models/request/UsuarioInfo.request';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  
  public static logeado:boolean;
  public static usuario:Usuario;
  // httpOptions = {
  //   headers: new HttpHeaders()
  //   .set('Authorization','eyJ1c2VyIjoiTHVjaG8iLCJwYXNzd29yZCI6IjEyMyJ9')
  // };

  constructor(private http:HttpClient,
              public usuario:Usuario) {

                UsuarioService.logeado = false;

               }

  public saludo(){
    let url = URL_AUTHENTICATION_SERVICE + "hola";
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'text/plain',
        'Authorization': 'eyJ1c2VyIjoiTHVjaG8iLCJwYXNzd29yZCI6IjEyMyJ9',
        'Access-Control-Allow-Origin':'*'
      })
    };

    console.log(url);

    this.http.get(url).subscribe(data=>{
      console.log(data);
    });
  
  }

  public saveInfo(usuario:Usuario):Promise<Response<Usuario>>{
    
    let url = URL_USER_SERVICE + "saveInfo";

    return new Promise<Response<Usuario>>((resolve,reject)=>{
      let infoReq:Request<UsuarioInfoRequest> = new Request<UsuarioInfoRequest>();
      infoReq.usuario = usuario.codigo;
      infoReq.contenido = new UsuarioInfoRequest();
      infoReq.contenido.usuarioInfo = usuario.info;
      infoReq.contenido.usuarioInfo.apellido = "1";
      infoReq.contenido.usuarioInfo.datosProfes  ="asd";
      infoReq.contenido.usuarioInfo.habitos ="asd";
      infoReq.contenido.usuarioInfo.idiomas =" asdd";
      
      infoReq.contenido.mail = usuario.mail;
      console.log(infoReq);
      this.http.post<Response<Usuario>>(url,infoReq).subscribe((data=>{
            
        if(data.estado.hayError){
            reject(data.estado.mensaje);
          }else{
            resolve(data);
          }

      }), (err)=>{
      console.log(err);
        reject('Ocurrió un error inesperado');
      });

    });
    
  }
  
  public logearse(logRequest:LoginRequest):Promise<Response<Usuario>> {//:Promise<Response<Usuario>>{

    let url = URL_AUTHENTICATION_SERVICE + "login";

    return new Promise<Response<Usuario>>((resolve,reject)=>{
  
      this.http.post<Response<Usuario>>(url,logRequest).subscribe((data=>{
        console.log(data);
        
        if(data.estado.hayError){
          reject(data.estado.mensaje);
        }
        UsuarioService.logeado = true;
        UsuarioService.usuario = data.contenido;
        resolve(data);

      }),
      (err)=>{
        console.log(err);
        reject(err);
      });
    
    });
  }

  public registrarse(regReq:RegistroRequest):Promise<Response<Usuario>> {//:Promise<Response<Usuario>>{

    let url = URL_AUTHENTICATION_SERVICE + "register";

    return new Promise<Response<Usuario>>((resolve,reject)=>{
  
      this.http.post<Response<Usuario>>(url,regReq).subscribe((data=>{
        
        if(data.estado.hayError){
          reject(data.estado.mensaje);
        }
        
        resolve(data);

      }),
      (err)=>{
        console.log(err);
        reject(err);
      });
    
    });
  }
}


@Injectable()
export class CustomInterceptor implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      
        if (!req.headers.has('Content-Type')) {
            req = req.clone({ headers: req.headers.set('Content-Type', 'application/json') });
        }

        if (!req.headers.has('Access-Control-Allow-Origin')) {
          req = req.clone({ headers: req.headers.append('Access-Control-Allow-Origin', '*') });
      }

      if (!req.headers.has('Access-Control-Allow-Methods')) {
        req = req.clone({ headers: req.headers.append('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, PUT, DELETE') });
    }
       
      req = req.clone({ headers: req.headers.set('Accept', 'application/json') });
      return next.handle(req);
    }
  }

