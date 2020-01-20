import { Rango } from './Rango.model';
import { Pais } from './Pais.model';

export class Sujeto{
    public id?:string;
    public codigo?:string;
    public alias?:string;
    public imagen?:string;
    public rango?:Rango;
    public pais?:Pais;
}