import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostVisualizaComponent } from './post-visualiza.component';

describe('PostVisualizaComponent', () => {
  let component: PostVisualizaComponent;
  let fixture: ComponentFixture<PostVisualizaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostVisualizaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostVisualizaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
