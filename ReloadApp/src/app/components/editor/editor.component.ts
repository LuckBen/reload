import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import * as $ from 'jquery';
import 'wysibb';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent implements OnInit {

  public ngOnInit() {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    $(function() {
      $("#editor").wysibb();
    });
  }

  constructor() { }

  inicioFocus:number;
  finFocus:number;
  contentModel:string;
  contentPreview:string;



  bold(field){

  

    let htmlContent:string =  document.getElementById('contenedor').innerHTML.substring(this.inicioFocus,this.finFocus);
    let htmlContentComplete = document.getElementById('contenedor').innerHTML;
    let htmlContentFirst:string ;
    let htmlContentLast:string;
    let i =  htmlContentComplete.indexOf(htmlContent);
    htmlContentFirst = htmlContentComplete.substring(0,i);
    htmlContentLast = htmlContentComplete.substring(this.finFocus, htmlContentComplete.length - this.finFocus);

    let indx:number = htmlContent.indexOf('<b>');
    if( indx >= 0 ){
      htmlContent = htmlContent.replace('<b>', '');
      htmlContent = htmlContent.replace('</b>', '');
    }else{
      htmlContent = '<b> ' + htmlContent + '</b>';
    }
    document.getElementById('contenedor').innerHTML =  htmlContentFirst + htmlContent + htmlContentLast ;
    
  }
  
  getCaretPosition(field){
    this.inicioFocus = field.selectionStart;
    this.finFocus = field.selectionEnd;  
  }

  getText(text){
    console.log(text);

  }
}
