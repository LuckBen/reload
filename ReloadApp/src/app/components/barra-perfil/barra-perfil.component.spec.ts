import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BarraPerfilComponent } from './barra-perfil.component';

describe('BarraPerfilComponent', () => {
  let component: BarraPerfilComponent;
  let fixture: ComponentFixture<BarraPerfilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BarraPerfilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BarraPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
