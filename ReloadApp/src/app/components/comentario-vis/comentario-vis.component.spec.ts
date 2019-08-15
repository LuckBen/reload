import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComentarioVisComponent } from './comentario-vis.component';

describe('ComentarioVisComponent', () => {
  let component: ComentarioVisComponent;
  let fixture: ComponentFixture<ComentarioVisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComentarioVisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComentarioVisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
