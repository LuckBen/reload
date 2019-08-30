import { Pipe, PipeTransform } from '@angular/core';
import { Rango } from '../models/Rango.model';

@Pipe({
  name: 'imgRango'
})
export class ImgRangoPipe implements PipeTransform {

  transform(value: string): string {
    console.log(value);
    let img:string = '../../../assets/img/icons/ran/' + value;
    return img;
  }


  
}
