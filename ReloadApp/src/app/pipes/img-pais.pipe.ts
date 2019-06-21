import { Pipe, PipeTransform } from '@angular/core';
import { Pais } from '../models/Pais.model';

@Pipe({
  name: 'imgPais'
})
export class ImgPaisPipe implements PipeTransform {

  transform(value: Pais): string  {
    let img:string ='../../../../assets/img/flags/'+value.codigo.toLowerCase() + '.png';
    console.log(img); 
    return  img;

  }

}
