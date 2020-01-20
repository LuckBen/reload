import { Component, OnInit, Inject, Input, ViewChild, ElementRef } from '@angular/core';
import * as $ from 'jquery';
import 'wysibb';
import { HelperService } from '../../../services/helper.service';
import { Categoria } from '../../../models/Categoria.model';
import { Post } from '../../../models/Post.model';
import { PostService } from '../../../services/post.service';
import { UsuarioService } from '../../../services/usuario.service';
import { Sujeto } from 'src/app/models/Sujeto.model';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { PostContenidoComponent } from '../post-contenido/post-contenido.component';
import { PostsComponent } from '../../posts/posts.component';
import { InputComponent } from '../../otros/input/input.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { PostVisualizaComponent } from '../post-visualiza/post-visualiza.component';

@Component({
  selector: 'app-crear-post',
  templateUrl: './crear-post.component.html',
  styleUrls: ['./crear-post.component.css']
})
export class CrearPostComponent implements OnInit {

  cargando:boolean;
  imgPost:string;
  imgB64:string;
  etiquetas:string;
  titulo:string;
  contenido:string;
  seComenta:boolean;
  categoriaID:string;
  categorias:Categoria[] = [];

  idPost:any;
  editar:boolean;
  
  constructor(private _helper:HelperService, 
              private _postService:PostService, 
              private _messageBox: MatSnackBar,
              private dialog: MatDialog,
              private _router:Router,
              private _activatedRoute:ActivatedRoute) {

    this._helper.getCategorias().then(data=>{
      this.categorias = data.contenido;
    });

  }
  
  getImagen(){
    const result = this.dialog.open(InputComponent);
    result.afterClosed().subscribe(data=>{
    });    
  }

  public ngOnInit() {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    $(function() {
      $("#editor").wysibb();
    });
    
    let idpost = this._activatedRoute.snapshot.params.idpost;
    
    if(idpost){
      this.idPost = idpost;
      this.editar = true;
      this.cargando = true;
      
      this._postService.getPost(this.idPost).then(data=>{  
        this.contenido = data.contenido;
      
        $(function() {
          
          $("#editor").htmlcode(this.contenido);
        });
        
      }).finally(()=>{
        this.cargando = false;
      });
    }
  }
  
  previsualizarPost(){
    
    let strCont: string = this.getContenido();

    const result = this.dialog.open(PostVisualizaComponent,{
      data:{ strCont}
    });

    result.afterClosed().subscribe(data=>{
    });
  }
  


  getContenido():any{
     return document.getElementsByClassName("wysibb-text-editor wysibb-body")[0].innerHTML;
  }

  publicar(){
   
    // console.log((document.getElementById("editor") as HTMLTextAreaElement).value);
    // console.log(document.getElementById('editor'));

    let post = new Post;
    post.contenido =  this.getContenido();  
    post.contenidoEditor = post.contenido;
    // $(function() {
    //   post.contenidoEditor =  $("#editor").bbcode();
    //   post.contenido =  $("#editor").htmlcode();
      
    // if(post.contenido.length > 10000){
    //   return;
    // }

    
    post.etiquetas = this.etiquetas;
    post.imagen = this.imgPost;
    post.titulo = this.titulo;
    post.propietario = new Sujeto();
    post.propietario.id = UsuarioService.usuario.id;
    post.propietario.alias = "??";
    post.propietario.codigo = UsuarioService.usuario.codigo;
    post.propietario.pais = UsuarioService.usuario.info.pais;
    post.propietario.rango = UsuarioService.usuario.rango;
    post.propietario.imagen = UsuarioService.usuario.info.imagen;
    post.seComenta = this.seComenta;
    post.contenidoEditor = this.contenido;
    post.categoria = new Categoria();
    post.categoria = this.categorias.filter((c)=>{
        return c.id == this.categoriaID
    })[0];
    post.categoria.id = this.categoriaID;
    post.tags = this.etiquetas.split(",");
    this.cargando = true;

    this._postService.publicar(post).then(data=>{
      this.show('Publicado con éxito','Genial!');
      console.log(data);
      this._router.navigate(['/post', data.id]);
    }).catch((err)=>{
      this.show(err,'Error');
    }).finally(()=>{
        this.cargando = false;
    });
  // });
      
  }

  show(message: string, action: string) {
    this._messageBox.open(message, action, {
      duration: 2000,
    });
  }


  cargarImagen(event){
    this.imgB64 = event;
  }
}


