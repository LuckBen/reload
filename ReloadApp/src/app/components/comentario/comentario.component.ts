import { Component, OnInit, Input } from '@angular/core';
import * as $ from 'jquery';
import 'wysibb';
import { Post } from '../../models/Post.model';
import { PostService } from '../../services/post.service';
import { Comentario } from 'src/app/models/Comentario.model';
import { UsuarioService } from '../../services/usuario.service';
import { Sujeto } from '../../models/Sujeto.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-comentario',
  templateUrl: './comentario.component.html',
  styleUrls: ['./comentario.component.css']
})
export class ComentarioComponent implements OnInit {

  @Input()esPost:boolean;
  @Input()esPublicacion:boolean;
  @Input()post:Post;
  cargando:boolean;

  constructor(private _postService:PostService, private _messageBox: MatSnackBar) {

  }

  ngOnInit() {
    $(function() {
      $("#editor").wysibb();
      
    });
  }

  comentar(){
    let comentario:Comentario = new Comentario();
    comentario.postid = this.post.id;
    
    comentario.contenido = document.getElementsByClassName("wysibb-text-editor wysibb-body")[0].innerHTML;
    
    comentario.emisor = new Sujeto();
    comentario.emisor.id = UsuarioService.usuario.id;
    comentario.emisor.codigo = UsuarioService.usuario.codigo;
    comentario.emisor.imagen = UsuarioService.usuario.info.imagen;
    comentario.emisor.pais = UsuarioService.usuario.info.pais;
    comentario.emisor.rango = UsuarioService.usuario.rango;
    
    this.cargando = true;

    this._postService.comentar(comentario).then(data=>{
      this.post.comentarios.push(data);
    }).catch((err)=>{
      this._messageBox.open(err,'Error! :(');
    }).finally(()=>{
      this.cargando = false;
    });

  }

}
