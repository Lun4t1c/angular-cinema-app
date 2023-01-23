import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMovieShowingComponent } from './add-movie-showing.component';

describe('AddMovieShowingComponent', () => {
  let component: AddMovieShowingComponent;
  let fixture: ComponentFixture<AddMovieShowingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddMovieShowingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddMovieShowingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
