import { Component, OnInit, Input, AfterContentInit } from '@angular/core';
import { Comentario } from '../../models/Comentario.model';

@Component({
  selector: 'app-comentario-vis',
  templateUrl: './comentario-vis.component.html',
  styleUrls: ['./comentario-vis.component.css']
})
export class ComentarioVisComponent implements OnInit, AfterContentInit {

  @Input()comentario:Comentario;
  @Input()index:number;
  id:string;

  constructor() { 
    this.id = (Math.random()*100).toString();
    console.log("1");
  }

  ngOnInit() {
    console.log("2");
  }
  
  ngAfterContentInit(){
    //let tam = document.getElementsByClassName("contenidoComentario").length;
    document.getElementsByClassName("contenidoComentario")[this.index].innerHTML = this.comentario.contenido;

    console.log("3");



  }
}
