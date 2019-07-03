import { Injectable } from '@angular/core';
import { FileItem } from '../models/FileItem.model';

@Injectable({
  providedIn: 'root'
})
export class CargaArchivosService {

  private CARPETA_IMAGENES = 'imgs/uploads';


  constructor() { }
  
  subirImagen(imagen:FileItem){

  }

  subirImagenes(imagenes:FileItem[]){

  }

  getBase64(event) {
    
    let file = event.target.files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      //me.modelvalue = reader.result;
      console.log(reader.result);
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
 }
}
