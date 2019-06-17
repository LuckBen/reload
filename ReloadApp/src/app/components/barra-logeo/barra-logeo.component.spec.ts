import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BarraLogeoComponent } from './barra-logeo.component';

describe('BarraLogeoComponent', () => {
  let component: BarraLogeoComponent;
  let fixture: ComponentFixture<BarraLogeoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BarraLogeoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BarraLogeoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
