import { Estado } from '../Estado.model';

export class Response<T>
{
    public contenido:T;
    public estado:Estado;
    public extra:string;
}