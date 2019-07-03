import { Component, OnInit, Input, Output,EventEmitter } from '@angular/core';
import { FileItem } from 'src/app/models/FileItem.model';
import { CargaArchivosService } from '../../services/carga-archivos.service';

@Component({
  selector: 'app-carga-archivos',
  templateUrl: './carga-archivos.component.html',
  styleUrls: ['./carga-archivos.component.css']
})
export class CargaArchivosComponent implements OnInit {
  estaSobreElemento = false;
  archivos: FileItem[] = [];
  imageSrc: string = '';
  @Output() getInfo64 = new EventEmitter();

  handleInputChange(e) {
    var file = e.dataTransfer ? e.dataTransfer.files[0] : e.target.files[0];
    var pattern = /image-*/;
    var reader = new FileReader();
    if (!file.type.match(pattern)) {
      alert('invalid format');
      return;
    }
    reader.onload = this._handleReaderLoaded.bind(this);
    reader.readAsDataURL(file);
  }
  _handleReaderLoaded(e) {
    let reader = e.target;
    this.imageSrc = reader.result;
    this.getInfo64.emit( this.imageSrc);
  }
  
  constructor(public _cargaImagenes: CargaArchivosService ) {
    this.getInfo64 = new EventEmitter();
    this.imageSrc = "./assets/img/drop-images.png";
   }

  ngOnInit() {
  }

  cargarImagenes() {
    this._cargaImagenes.subirImagen( this.archivos[0] );
  }

  limpiarArchivos() {
    this.archivos = [];
  }



}
