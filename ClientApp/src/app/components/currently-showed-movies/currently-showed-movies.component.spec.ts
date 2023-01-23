import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentlyShowedMoviesComponent } from './currently-showed-movies.component';

describe('CurrentlyShowedMoviesComponent', () => {
  let component: CurrentlyShowedMoviesComponent;
  let fixture: ComponentFixture<CurrentlyShowedMoviesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CurrentlyShowedMoviesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CurrentlyShowedMoviesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
