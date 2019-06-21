import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from 'src/app/models/Usuario.model';


@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  codigo:any;
  cargando:boolean;
  usuario:Usuario;
  constructor(private route:ActivatedRoute,
              private usService:UsuarioService) { }

  ngOnInit() {
    this.cargando = true;
      this.codigo = this.route.snapshot.params.codigo;
      this.usService.obtenerUsuario(this.codigo).then(data=>{
      this.usuario = data.contenido;
    }).catch(data =>{
        console.log(data);
    }).finally(()=>{
      this.cargando = false;
    });
  }

}
