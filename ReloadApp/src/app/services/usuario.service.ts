import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpInterceptor, HttpHandler, HttpEvent, HttpRequest } from  '@angular/common/http';
import { Usuario } from '../models/Usuario.model';
import { RegistroRequest } from '../models/request/registro.request';
import { URL_AUTHENTICATION_SERVICE } from './urlservicios.url';
import { Response } from '../models/response/registro.response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  
  public static logeado:boolean;
  
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
  
  public registrarse(regReq:RegistroRequest) {//:Promise<Response<Usuario>>{

    // return new Promise<Response<Usuario>>((resolve,reject)=>{
    let url = URL_AUTHENTICATION_SERVICE + "register";
 


    this.http.post(url,regReq).subscribe(data=>{
      console.log(data);
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

