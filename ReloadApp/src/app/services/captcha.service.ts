import { Injectable } from '@angular/core';
import { Response } from '../models/response/response.response';
import { Captcha } from '../models/Captcha.model';
import { URL_AUTHENTICATION_SERVICE } from './urlservicios.url';
import { HttpClient, HttpHeaders, HttpParams, HttpInterceptor, HttpHandler, HttpEvent, HttpRequest } from  '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CaptchaService {

  constructor(private http:HttpClient) {


  }

  public getCaptcha():Promise<Response<Captcha>>{
    
    let url = URL_AUTHENTICATION_SERVICE + 'getCaptcha';

    return new Promise<Response<Captcha>>((resolve,reject) => {
      this.http.get<Response<Captcha>>(url).subscribe(resp => {
        if(resp.estado.hayError){
          reject(resp.estado.mensaje);
        }else{
          resolve(resp);
        }
      },(err)=>{
        console.log(err);

        reject(err);
      })  
    });
  }

}
