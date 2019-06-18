import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-barra-perfil',
  templateUrl: './barra-perfil.component.html',
  styleUrls: ['./barra-perfil.component.css']
})
export class BarraPerfilComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit() {
  }
  cuenta(){
    this.router.navigate(['/cuenta']);
  }
}
