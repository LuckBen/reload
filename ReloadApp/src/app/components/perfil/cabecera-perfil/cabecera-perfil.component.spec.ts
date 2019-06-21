import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CabeceraPerfilComponent } from './cabecera-perfil.component';

describe('CabeceraPerfilComponent', () => {
  let component: CabeceraPerfilComponent;
  let fixture: ComponentFixture<CabeceraPerfilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CabeceraPerfilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CabeceraPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
