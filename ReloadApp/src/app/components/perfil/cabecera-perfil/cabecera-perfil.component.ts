import { Component, OnInit, Input } from '@angular/core';
import { Usuario } from 'src/app/models/Usuario.model';

@Component({
  selector: 'app-cabecera-perfil',
  templateUrl: './cabecera-perfil.component.html',
  styleUrls: ['./cabecera-perfil.component.css']
})
export class CabeceraPerfilComponent implements OnInit {

  @Input()usuario:Usuario;

  constructor() { }

  ngOnInit() {
  }

}
