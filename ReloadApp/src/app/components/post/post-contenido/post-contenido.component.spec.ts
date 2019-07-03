import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostContenidoComponent } from './post-contenido.component';

describe('PostContenidoComponent', () => {
  let component: PostContenidoComponent;
  let fixture: ComponentFixture<PostContenidoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostContenidoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostContenidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
