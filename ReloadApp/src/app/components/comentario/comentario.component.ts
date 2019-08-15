import { Component, OnInit, Input } from '@angular/core';
import * as $ from 'jquery';
import 'wysibb';
import { Post } from '../../models/Post.model';
import { PostService } from '../../services/post.service';
import { Comentario } from 'src/app/models/Comentario.model';
import { UsuarioService } from '../../services/usuario.service';
import { Sujeto } from '../../models/Sujeto.model';

@Component({
  selector: 'app-comentario',
  templateUrl: './comentario.component.html',
  styleUrls: ['./comentario.component.css']
})
export class ComentarioComponent implements OnInit {

  @Input()esPost:boolean;
  @Input()esPublicacion:boolean;
  @Input()post:Post;

  constructor(private _postService:PostService) {

  }

  ngOnInit() {
    $(function() {
      $("#editor").wysibb();
      
    });
  }

  comentar(){
    let comentario:Comentario = new Comentario();
    comentario.postid = this.post._id;
    
    comentario.contenido = document.getElementsByClassName("wysibb-text-editor wysibb-body")[0].innerHTML;
    console.log(comentario.contenido);
    comentario.emisor = new Sujeto();
    comentario.emisor._id = UsuarioService.usuario._id;
    comentario.emisor.codigo = UsuarioService.usuario.codigo;
    comentario.emisor.imagen = "..";
    comentario.emisor.pais = UsuarioService.usuario.info.pais;
    comentario.emisor.rango = UsuarioService.usuario.rango;
    console.log(comentario);
    this._postService.comentar(comentario);
  }

}
