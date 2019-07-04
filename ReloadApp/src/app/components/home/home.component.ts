import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../../models/Post.model';
import { PostService } from '../../services/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  postsRecientes:Post[] = [];
  postsDestacados:Post[] = [];
  cargandoRecientes:boolean;
  cargandoDestacados:boolean;
  cargandoAs:boolean;
  constructor(private router:Router,
              private postService:PostService ) {
                this.cargandoRecientes = false;
  }


  ngOnInit() {
      this.cargarRecientes();
      this.cargarDestacados();
  }
  crearPost(){
    this.router.navigate(['/crear/post'])

  }
  
  irPost(p:Post){
    this.router.navigate(['/post', p._id]);
  }
  cargarDestacados(){
    this.cargandoDestacados = true;
    this.postService.getDestacados().then(data=>{
      this.postsDestacados = data;
    }).finally(()=>{
      this.cargandoDestacados = false;
    });
  }
  cargarRecientes(){
    
    this.cargandoRecientes = true;
    this.postService.getRecientes().then((data)=>{
      this.postsRecientes = data;   
     }).finally(()=>{
      this.cargandoRecientes = false;
     });
  }

}
