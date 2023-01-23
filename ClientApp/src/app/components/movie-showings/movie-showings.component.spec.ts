import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieShowingsComponent } from './movie-showings.component';

describe('MovieShowingsComponent', () => {
  let component: MovieShowingsComponent;
  let fixture: ComponentFixture<MovieShowingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieShowingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovieShowingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
