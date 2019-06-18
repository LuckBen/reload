import { Pais } from './Pais.model';

export class UsuarioInfo{
    public nombre:string;
    public apellido:string;
    public pais:Pais;
    public sexo:string;
    public fechaNac:Date
    public idiomas:string;
    public datosProfes:string;
    public habitos:string;
    public propiasPalabras:string;

    constructor(){
 
    }
}