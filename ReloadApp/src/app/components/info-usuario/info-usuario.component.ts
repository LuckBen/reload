import { Component, OnInit, Input } from '@angular/core';
import { Sujeto } from 'src/app/models/Sujeto.model';

@Component({
  selector: 'app-info-usuario',
  templateUrl: './info-usuario.component.html',
  styleUrls: ['./info-usuario.component.css']
})
export class InfoUsuarioComponent implements OnInit {

   @Input()usuario:Sujeto;
  constructor() { }

  ngOnInit() {
  }

}
