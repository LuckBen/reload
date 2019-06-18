import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-barra-logeo',
  templateUrl: './barra-logeo.component.html',
  styleUrls: ['./barra-logeo.component.css']
})
export class BarraLogeoComponent implements OnInit {

  constructor(private router:Router ) {
  }

  ngOnInit() {
  }

  login(){
    this.router.navigate(['/login'])
  }

  registro(){
    this.router.navigate(['/registro'])

  }
}
