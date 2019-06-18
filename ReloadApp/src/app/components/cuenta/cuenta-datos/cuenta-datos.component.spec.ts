import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CuentaDatosComponent } from './cuenta-datos.component';

describe('CuentaDatosComponent', () => {
  let component: CuentaDatosComponent;
  let fixture: ComponentFixture<CuentaDatosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CuentaDatosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CuentaDatosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
