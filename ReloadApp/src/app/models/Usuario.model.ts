import { Rango } from './Rango.model';
import { UsuarioInfo  } from "./UsuarioInfo.model";
import { Medalla  } from "./Medalla.model";
import { Post } from './Post.model';
import { Sujeto } from './Sujeto.model';
import { Comentario } from './Comentario.model';
import { Suspension } from './Suspension.model';

export class Usuario{

    public id:string;
    public codigo:string;
    public password?:string;
    public puntos?:number;
    public mail?:string;
    public activo?:boolean;
    public rango?:Rango;
    public info?:UsuarioInfo;
    public medalla?:Medalla[];
    public posts?:Post[];
    public seguidores?:Sujeto[];
    public siguiendo?:Sujeto[];
    public mensajes?:Comentario[];
    public suspension?:Suspension;
    public nroComentarios?:number;

    constructor(){
        this.id = "";
        this.codigo ="";
        this.password = "";
        this.puntos = 0;
        this.mail = "";
        this.activo = false;
        this.rango = new Rango();
        this.info = new  UsuarioInfo();
        

    }
}