import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from '../../../services/post.service';
import { Post } from '../../../models/Post.model';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-post-contenido',
  templateUrl: './post-contenido.component.html',
  styleUrls: ['./post-contenido.component.css']
})
export class PostContenidoComponent implements OnInit {
  
  post:Post;
  cargando:boolean;
  logeado:boolean;
  propio:boolean = false;

  constructor(private activatedRoute: ActivatedRoute,
              private postService:PostService,
              private _router:Router ) {

    this.cargando = true;
    this.logeado = !(UsuarioService.usuario == null);

 
    let date = this.activatedRoute.snapshot.params.idpost;

    this.postService.getPost(date).then(data=>{
      this.post = data;
      document.getElementById("contenido").innerHTML = this.post.contenido;

      if(this.logeado){
        this.propio = (this.post.propietario.codigo == UsuarioService.usuario.codigo);
      }

      
    }).catch((ex)=>{
    }).finally(()=>{
      this.cargando = false;
    });

  }

  editar(){
    this._router.navigate(['/editarPost',this.post._id]);
  }


  ngOnInit() {
  }

}
