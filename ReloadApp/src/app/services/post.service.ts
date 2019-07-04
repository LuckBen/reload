import { Injectable } from '@angular/core';
import { Pais } from '../models/Pais.model';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { Response } from '../models/response/response.response';
import { Request } from '../models/request/Request.request';
import { Categoria } from '../models/Categoria.model';
import { Post } from '../models/Post.model';
import { URL_POST_SERVICE } from './urlservicios.url';
import { UsuarioService } from './usuario.service';
import { post } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  getDestacados():Promise<Post[]> {
    let url = URL_POST_SERVICE + 'destacados/comentarios';
    return new Promise<Post[]>((resolve,reject)=>{
      this._http.get<Response<Post[]>>(url).subscribe((data)=>{
        if(data.estado.hayError){
          reject(data.estado.mensaje);
        }else{
          resolve(data.contenido);
        }
      },(err)=>{
        reject('Ocurrió un error inesperado');
      });
    });
  }
  
  getPost(date: string):Promise<Post> {
    let url = URL_POST_SERVICE + 'post/' + date;
    return new Promise((resolve,reject)=>{
      this._http.get<Response<Post>>(url).subscribe(data=>{
        if(data.estado.hayError){
          reject(data.estado.mensaje);
        }else{
          resolve(data.contenido);
        }
      },(err)=>{
        reject('Ocurrió un error inesperado');
      });
    });
  }

  getRecientes(): Promise<Post[]> {
    let url = URL_POST_SERVICE + 'recientes';
    return new Promise<Post[]>((resolve,reject)=>{
        this._http.get<Response<Post[]>>(url).subscribe((data)=>{
          if(data.estado.hayError){
            reject(data.estado.mensaje);
          }else{
            resolve(data.contenido);
          }
        },(err)=>{
          reject('Ocurrió un error inesperado');
        });
    });
  }

  constructor(private _http:HttpClient) { }

  publicar(post:Post):Promise<Post>{
    let url = URL_POST_SERVICE + 'publicar';
    let req:Request<Post> = new Request<Post>();
    req.usuario = UsuarioService.usuario.codigo;
    req.contenido = post;
  
    return new Promise<Post>((resolve,reject)=>{
      this._http.post<Response<Post>>(url,req).subscribe((data)=>{
        if(data.estado.hayError){
          reject(data.estado.mensaje);
        }else{
          resolve(data.contenido);
        }

      },(err)=>{
        reject('Ocurrió un error inesperado');
      });
    });
 

  }

}
