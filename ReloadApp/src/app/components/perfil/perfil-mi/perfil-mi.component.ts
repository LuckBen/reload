import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import 'wysibb';
@Component({
  selector: 'app-perfil-mi',
  templateUrl: './perfil-mi.component.html',
  styleUrls: ['./perfil-mi.component.css']
})
export class PerfilMiComponent implements OnInit {


    public ngOnInit() {
      //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
      //Add 'implements OnInit' to the class.
      $(function() {
        $("#editor").wysibb();
      });
    }
  
  constructor() { }


}
