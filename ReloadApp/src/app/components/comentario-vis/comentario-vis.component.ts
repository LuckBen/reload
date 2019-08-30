import { Component, OnInit, Input, AfterContentInit } from '@angular/core';
import { Comentario } from '../../models/Comentario.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-comentario-vis',
  templateUrl: './comentario-vis.component.html',
  styleUrls: ['./comentario-vis.component.css']
})
export class ComentarioVisComponent implements OnInit, AfterContentInit {

  @Input()comentario:Comentario;
  @Input()index:number;
  id:string;

  constructor(private router:Router) { 
    this.id = (Math.random()*100).toString();
  }

  ngOnInit() {
  }
  
  ngAfterContentInit(){
    //let tam = document.getElementsByClassName("contenidoComentario").length;
    document.getElementsByClassName("contenidoComentario")[this.index].innerHTML = this.comentario.contenido;

  }

  irPerfil(){
    this.router.navigate(['/perfil', this.comentario.emisor.codigo]);
  }

}
