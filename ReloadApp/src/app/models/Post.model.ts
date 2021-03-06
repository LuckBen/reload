import { Sujeto } from './Sujeto.model';
import { Categoria } from './Categoria.model';
import { Comentario } from './Comentario.model';

export class Post{
    public id?:string;
    public propietario:Sujeto;
    public titulo:string;
    public imagen?:string;
    public contenido:string;
    public categoria?:Categoria;
    public tags?:string[];
    public puntos?:number;
    public sticky?:boolean;
    public visitas?:number;
    public favoritos?:number;
    public seguidores?:number;
    public fechaAlta?:string;
    public fechaModificacion?:string;
    public activo:Boolean;
    public comentarios?:Comentario[];
    public etiquetas:string;
    public seComenta:boolean;
    public contComentarios:number;
    public contenidoEditor:string;
}