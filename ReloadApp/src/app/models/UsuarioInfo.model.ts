import { Pais } from './Pais.model';

export class UsuarioInfo{
    public nombre:string;
    public apellido:string;
    public pais:Pais;
    public sexo:string;
    public fechaNac:string;
    public idiomas:string;
    public datosProfes:string;
    public habitos:string;
    public propiasPalabras:string;
    public fechaAlta:string;
    public imagen?:string;
    constructor(){
 
    }
}