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
import { CambioClaveRequest } from '../models/request/CambioClave.request';

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

  constructor(private http:HttpClient) {
                UsuarioService.logeado = false;
               }
  
  public  cargar(){
    UsuarioService.usuario = JSON.parse(localStorage.getItem('usuario'));

    if(UsuarioService.usuario){
      let login:LoginRequest = new LoginRequest();
      login.login = UsuarioService.usuario.codigo;
      login.password = UsuarioService.usuario.password;
        
      this.logearse(login).then((data)=>{
          console.log(data);
      }).catch((data)=>{
        console.log(data);

      }).finally(()=>{
          console.log('listo');  
      });
    }
  }               
  public  guardar(){
    localStorage.setItem('usuario',JSON.stringify(UsuarioService.usuario));
  }

  public  saludo(){
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

  public   saveInfo(_usuario:Usuario):Promise<Response<Usuario>>{
    
    let url = URL_USER_SERVICE + "saveInfo";

    return new Promise<Response<Usuario>>((resolve,reject)=>{
      let infoReq:Request<UsuarioInfoRequest> = new Request<UsuarioInfoRequest>();
      infoReq.usuario = _usuario.codigo;
      infoReq.token = "asd";
      infoReq.contenido = new UsuarioInfoRequest();
      infoReq.contenido.usuarioInfo = _usuario.info;      
      infoReq.contenido.mail = _usuario.mail;
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
  
  public  logearse(logRequest:LoginRequest):Promise<Response<Usuario>> {//:Promise<Response<Usuario>>{

    let url = URL_AUTHENTICATION_SERVICE + "login";

    return new Promise<Response<Usuario>>((resolve,reject)=>{
  
      this.http.post<Response<Usuario>>(url,logRequest).subscribe((data=>{

        if(data.estado.hayError){
          reject(data.estado.mensaje);
        }
        UsuarioService.logeado = true;
        UsuarioService.usuario = data.contenido;
        resolve(data);
        this.guardar();
      }),
      (err)=>{
        console.log(err);
        reject('Ocurrió un error inesperado');
      });
    
    });
  }

  public  cambiarClave(claveActual:string, claveNueva:string):Promise<Response<string>>{
    
    let url = URL_USER_SERVICE + 'cambiarClave'
    let reqCambioClave:Request<CambioClaveRequest> = new Request<CambioClaveRequest>();
    reqCambioClave.usuario = UsuarioService.usuario.codigo;
    reqCambioClave.contenido = new CambioClaveRequest();
    reqCambioClave.contenido.claveActual = claveActual;
    reqCambioClave.contenido.claveNueva = claveNueva;
    reqCambioClave.token = "1";

    return new Promise<Response<string>>((resolve,reject) =>{
        this.http.post<Response<string>>(url,reqCambioClave).subscribe((data) =>{
            if(data.estado.hayError){
              reject(data.estado.mensaje);  
            }else{
              resolve(data);
            }
        }, (err)=>{
            reject('Ocurrió un error inesperado');
        }); 
    });
  }

  public  obtenerUsuario(codigo:string):Promise<Response<Usuario>>{
    
    let url = URL_AUTHENTICATION_SERVICE + 'obtenerUsuario';
    let request:Request<string> = new Request<string>();
    request.contenido = codigo;
    request.token = "1";
    request.usuario = UsuarioService.usuario.codigo;
    return new Promise<Response<Usuario>>((resolve,reject)=>{
      this.http.post<Response<Usuario>>(url,request).subscribe(data=>{
        if(data.estado.hayError){
          reject(data);
        }else{
          resolve(data);
        }
      },(err)=>{
        reject('Ocurrió un error inesperado');
      });
    });
  }

  public  registrarse(regReq:RegistroRequest):Promise<Response<Usuario>> {//:Promise<Response<Usuario>>{

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

