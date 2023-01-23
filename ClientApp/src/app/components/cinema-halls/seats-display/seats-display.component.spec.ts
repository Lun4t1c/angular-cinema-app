import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatsDisplayComponent } from './seats-display.component';

describe('SeatsDisplayComponent', () => {
  let component: SeatsDisplayComponent;
  let fixture: ComponentFixture<SeatsDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeatsDisplayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SeatsDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
