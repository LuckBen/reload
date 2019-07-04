import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostService } from '../../../services/post.service';
import { Post } from '../../../models/Post.model';

@Component({
  selector: 'app-post-contenido',
  templateUrl: './post-contenido.component.html',
  styleUrls: ['./post-contenido.component.css']
})
export class PostContenidoComponent implements OnInit {
  
  post:Post;
  cargando:boolean;
  constructor(private activatedRoute: ActivatedRoute,
              private postService:PostService) {
                this.cargando = true;
          let date = this.activatedRoute.snapshot.params.idpost;

          this.postService.getPost(date).then(data=>{
            this.post = data;
            document.getElementById("contenido").innerHTML = this.post.contenido;
          }).catch((ex)=>{
          }).finally(()=>{
            this.cargando = false;
          });
  }


  ngOnInit() {
  }

}
