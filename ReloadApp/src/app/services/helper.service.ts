import { Injectable } from '@angular/core';
import { Pais } from '../models/Pais.model';
import { HttpClient } from '@angular/common/http';
import { Response } from '../models/response/response.response';
import { URL_USER_SERVICE, URL_HELPER_SERVICE } from './urlservicios.url';
import { Categoria } from '../models/Categoria.model';

@Injectable({
  providedIn: 'root'
})
export class HelperService {
  
  public static paises:Pais[] = [];
  
  constructor(private http:HttpClient) {

  }

  public getPaises():Promise<Response<Pais[]>>{
    let url = URL_USER_SERVICE + 'paises';
    return new Promise<Response<Pais[]>>((resolve,reject)=>{
      this.http.get<Response<Pais[]>>(url).subscribe((data)=>{
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

  public getCategorias():Promise<Response<Categoria[]>>{
    let url = URL_HELPER_SERVICE + 'categorias';
    return new Promise<Response<Categoria[]>>((resolve,reject)=>{
      this.http.get<Response<Categoria[]>>(url).subscribe((data)=>{
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



}
