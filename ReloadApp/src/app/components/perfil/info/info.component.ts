import { Component, OnInit, Input } from '@angular/core';
import { Usuario } from '../../../models/Usuario.model';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {

  @Input()usuario:Usuario;

  constructor() { }

  ngOnInit() {
  }

}
