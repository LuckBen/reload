import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CuentaCambiarClaveComponent } from './cuenta-cambiar-clave.component';

describe('CuentaCambiarClaveComponent', () => {
  let component: CuentaCambiarClaveComponent;
  let fixture: ComponentFixture<CuentaCambiarClaveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CuentaCambiarClaveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CuentaCambiarClaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
