import { Component, OnInit, Inject, Input } from '@angular/core';
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
      console.log(data);
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
        document.getElementsByClassName("wysibb-text-editor wysibb-body")[0].innerHTML = this.contenido;
        console.log('okkkkkkkk');
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
      console.log(data);
    });
  }
  


  getContenido():any{
     return document.getElementsByClassName("wysibb-text-editor wysibb-body")[0].innerHTML;
  }

  publicar(){

    this.contenido = this.getContenido();  

    if(this.contenido.length > 10000){
      return;
    }

    let post = new Post;
    post.contenido = this.contenido;
    post.etiquetas = this.etiquetas;
    post.imagen = this.imgPost;
    post.titulo = this.titulo;
    post.propietario = new Sujeto();
    post.propietario._id = UsuarioService.usuario._id;
    post.propietario.alias = "??";
    post.propietario.codigo = UsuarioService.usuario.codigo;
    post.propietario.pais = UsuarioService.usuario.info.pais;
    post.propietario.rango = UsuarioService.usuario.rango;
    post.propietario.imagen = UsuarioService.usuario.info.imagen;
    post.seComenta = this.seComenta;
    post.categoria = new Categoria();
    post.categoria = this.categorias.filter((c)=>{
        return c._id == this.categoriaID
    })[0];
    post.categoria._id = this.categoriaID;
    post.tags = this.etiquetas.split(",");
    this.cargando = true;

    this._postService.publicar(post).then(data=>{
      this.show('Publicado con éxito','Genial!');
      console.log(data);
      this._router.navigate(['/post', data._id]);
    }).catch((err)=>{
      this.show(err,'Error');
    }).finally(()=>{
        this.cargando = false;
    });
    
      
  }

  show(message: string, action: string) {
    this._messageBox.open(message, action, {
      duration: 10000,
    });
  }


  cargarImagen(event){
    this.imgB64 = event;
  }
}


