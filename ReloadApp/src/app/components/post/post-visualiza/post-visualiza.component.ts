import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-post-visualiza',
  templateUrl: './post-visualiza.component.html',
  styleUrls: ['./post-visualiza.component.css']
})
export class PostVisualizaComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<PostVisualizaComponent>,
              @Inject(MAT_DIALOG_DATA) public data:any) { 

    document.getElementById("contenido").innerHTML = data;
  }

  ngOnInit() {
  }

}
