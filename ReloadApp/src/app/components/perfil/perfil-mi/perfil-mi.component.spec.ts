import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PerfilMiComponent } from './perfil-mi.component';

describe('PerfilMiComponent', () => {
  let component: PerfilMiComponent;
  let fixture: ComponentFixture<PerfilMiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PerfilMiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PerfilMiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
