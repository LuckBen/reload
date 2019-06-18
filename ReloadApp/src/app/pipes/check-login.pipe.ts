import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'checkLogin'
})
export class CheckLoginPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return null;
  }

}
