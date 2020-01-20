import { Sujeto } from './Sujeto.model';
export class Comentario{
    public id?:string;
    public postid:string;
    public emisor?:Sujeto;
    public receptor?:Sujeto;
    public contenido:string;
    public likes?:number;
    public dislikes?:number;
    public debaja?:boolean;
    public esMensajePrivado?:boolean;
    public fecha:Date;
    public respuestas?:Comentario[];
}