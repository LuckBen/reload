import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PerfilPostsComponent } from './perfil-posts.component';

describe('PerfilPostsComponent', () => {
  let component: PerfilPostsComponent;
  let fixture: ComponentFixture<PerfilPostsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PerfilPostsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PerfilPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
